﻿#region Using Directives
using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDMSInvestigation.Entities;
#endregion

namespace NDMSInvestigation.Web.Data
{
	/// <summary>
	/// The base class for all relationship controls.
	/// </summary>
	[ParseChildren(true), PersistChildren(false)]
	public abstract class EntityRelationship : WebControl
	{
		#region Declarations

		private EntityRelationshipMember _primaryMember;
		private EntityRelationshipMember _linkMember;
		private EntityRelationshipMember _referenceMember;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EntityRelationship class.
		/// </summary>
		public EntityRelationship()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets an instance of EntityRelationshipMember that
		/// represents the primary table in the relationship.
		/// </summary>
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public EntityRelationshipMember PrimaryMember
		{
			get { return _primaryMember; }
			set { _primaryMember = value; }
		}

		/// <summary>
		/// Gets or sets an instance of EntityRelationshipMember that
		/// represents the join table in the relationship.
		/// </summary>
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public EntityRelationshipMember LinkMember
		{
			get { return _linkMember; }
			set { _linkMember = value; }
		}

		/// <summary>
		/// Gets or sets an instance of EntityRelationshipMember that
		/// represents the foreign key table in the relationship.
		/// </summary>
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public EntityRelationshipMember ReferenceMember
		{
			get { return _referenceMember; }
			set { _referenceMember = value; }
		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// Raises the System.Web.UI.Control.Load event.
		/// </summary>
		/// <param name="e">The System.EventArgs object that contains the event data.</param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// add child controls
			if ( PrimaryMember != null )
			{
				this.Controls.Add(PrimaryMember);
			}
			if ( LinkMember != null )
			{
				this.Controls.Add(LinkMember);
			}
			if ( ReferenceMember != null )
			{
				this.Controls.Add(ReferenceMember);
			}

			ILinkedDataSource PrimaryDataSource = PrimaryMember.GetLinkedDataSource();
			if ( PrimaryDataSource != null )
			{
				PrimaryDataSource.AfterSelected += new LinkedDataSourceEventHandler(OnAfterSelected);
				PrimaryDataSource.AfterInserting += new LinkedDataSourceEventHandler(OnAfterInserting);
				PrimaryDataSource.AfterInserted += new LinkedDataSourceEventHandler(OnAfterInserted);
				PrimaryDataSource.AfterUpdating += new LinkedDataSourceEventHandler(OnAfterUpdating);
				PrimaryDataSource.AfterUpdated += new LinkedDataSourceEventHandler(OnAfterUpdated);
			}
		}

		private void OnAfterSelected(object sender, LinkedDataSourceEventArgs e)
		{
			if ( e.Index == PrimaryMember.EntityIndex )
			{
				PrimaryMember.CurrentEntity = e.Entity;
				PrimaryMember.DeepLoad();
				UpdateControl(e.Entity);
			}
		}

		private void OnAfterInserting(object sender, LinkedDataSourceEventArgs e)
		{
			if ( e.Index == PrimaryMember.EntityIndex )
			{
				PrimaryMember.CurrentEntity = e.Entity;

				if ( PrimaryMember.EnableDeepSave )
				{
					UpdateRelationships(e.Entity);
				}
			}
		}

		private void OnAfterInserted(object sender, LinkedDataSourceEventArgs e)
		{
			if ( e.Index == PrimaryMember.EntityIndex )
			{
				PrimaryMember.CurrentEntity = e.Entity;

				if ( !PrimaryMember.EnableDeepSave )
				{
					UpdateRelationships(e.Entity);
				}

				InsertLinks();
				InsertReferences();
			}
		}

		private void OnAfterUpdating(object sender, LinkedDataSourceEventArgs e)
		{
			if ( e.Index == PrimaryMember.EntityIndex )
			{
				PrimaryMember.CurrentEntity = e.Entity;
				PrimaryMember.DeepLoad();
				
				if ( PrimaryMember.EnableDeepSave )
				{
					UpdateRelationships(e.Entity);
				}
			}
		}

		private void OnAfterUpdated(object sender, LinkedDataSourceEventArgs e)
		{
			if ( e.Index == PrimaryMember.EntityIndex )
			{
				PrimaryMember.CurrentEntity = e.Entity;

				if ( !PrimaryMember.EnableDeepSave )
				{
					UpdateRelationships(e.Entity);
				}
			}
		}
		
		#endregion

		#region Methods
		/// <summary>
		/// Initializes and updates the control with the relationships
		/// held within the specified business object.
		/// </summary>
		/// <param name="entity"></param>
		protected virtual void UpdateControl(Object entity)
		{
		}

		/// <summary>
		/// Updates the specified business object with values bound to the
		/// control which represent the current relationships.
		/// </summary>
		/// <param name="entity"></param>
		protected virtual void UpdateRelationships(Object entity)
		{
		}

		#region LinkMember Methods

		/// <summary>
		/// Gets the collection of business objects from the associated <paramref name="LinkMember"/>.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns>A collection of business objects which represent the
		/// relationship defined by the <paramref name="LinkMember"/> property.</returns>
		protected IList GetLinkList(Object entity)
		{
			return GetList(entity, LinkMember, PrimaryMember.LinkProperty);
		}

		/// <summary>
		/// Inserts any previously cached business object links.
		/// </summary>
		protected void InsertLinks()
		{
			Insert(LinkMember);
		}

		/// <summary>
		/// Inserts the specified <paramref name="foreignKeyValue"/> into the
		/// relationship defined by the <paramref name="LinkMember"/> property.
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="foreignKeyValue">The value to insert.</param>
		protected void InsertLink(Object entity, Object foreignKeyValue)
		{
			IList links = GetLinkList(entity);
			InsertLink(links, foreignKeyValue);
		}

		/// <summary>
		/// Inserts the specified <paramref name="foreignKeyValue"/> into the
		/// collection of business objects.
		/// </summary>
		/// <param name="links">A collection of business objects.</param>
		/// <param name="foreignKeyValue">The value to insert.</param>
		protected void InsertLink(IList links, Object foreignKeyValue)
		{
			// make sure link doesn't exist
			Object link = EntityUtil.GetEntity(links, LinkMember.ForeignKeyName, foreignKeyValue);

			if ( link == null )
			{
				Object entityKeyValue = PrimaryMember.GetEntityId();

				IDictionary values = new Hashtable();
				values.Add(LinkMember.EntityKeyName, entityKeyValue);
				values.Add(LinkMember.ForeignKeyName, foreignKeyValue);

				// delayed insert
				if ( LinkMember.HasDataSource && entityKeyValue == null )
				{
					LinkMember.Inserts.Add(values);
				}
				else
				{
					Insert(LinkMember, links, values);
				}
			}
		}

		/// <summary>
		/// Removes the specified item from the collection of business objects.
		/// </summary>
		/// <param name="links">A collection of business objects.</param>
		/// <param name="link">The item to remove.</param>
		protected void RemoveLink(IList links, Object link)
		{
			Remove(LinkMember, links, link);
		}

		#endregion

		#region ReferenceMember Methods

		/// <summary>
		/// Gets the collection of business objects from the associated <paramref name="ReferenceMember"/>.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns>A collection of business objects which represent the
		/// relationship defined by the <paramref name="ReferenceMember"/> property.</returns>
		protected IList GetReferenceList(Object entity)
		{
			return GetList(entity, ReferenceMember, PrimaryMember.ReferenceProperty);
		}

		/// <summary>
		/// Inserts any previously cached business object references.
		/// </summary>
		protected void InsertReferences()
		{
			Insert(ReferenceMember);
		}

		/// <summary>
		/// Inserts the specified name/value pairs into the
		/// relationship defined by the <paramref name="ReferenceMember"/> property.
		/// </summary>
		/// <param name="links">A collection of business objects.</param>
		/// <param name="values">A collection of name/value pairs to insert.</param>
		protected void InsertReference(IList links, IDictionary values)
		{
			Object entityKeyValue = PrimaryMember.GetEntityId();

			// delayed insert
			if ( ReferenceMember.HasDataSource && entityKeyValue == null )
			{
				ReferenceMember.Inserts.Add(values);
			}
			else
			{
				Insert(ReferenceMember, links, values, true);
			}
		}

		/// <summary>
		/// Updates the specified business object with the specified name/value pairs.
		/// </summary>
		/// <param name="link">The business object to update.</param>
		/// <param name="values">A collection of name/value pairs to update.</param>
		protected void UpdateReference(Object link, IDictionary values)
		{
			Update(ReferenceMember, link, values);
		}

		/// <summary>
		/// Removes the specified item from the collection of business objects.
		/// </summary>
		/// <param name="links">A collection of business objects.</param>
		/// <param name="link">The item to remove.</param>
		protected void RemoveReference(IList links, Object link)
		{
			Remove(ReferenceMember, links, link);
		}

		#endregion

		#region Base EntityRelationshipMember Methods

		/// <summary>
		/// Gets the collection of business objects from the specified relationship member.
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="member">The relationship member.</param>
		/// <param name="listPropertyName">The property name.</param>
		/// <returns>A collection of business objects which represent the
		/// relationship defined by the specified relationship member.</returns>
		protected IList GetList(Object entity, EntityRelationshipMember member, String listPropertyName)
		{
			IList list;

			if ( member != null && member.HasDataSource )
			{
				// get list from data source
				list = member.GetEntityList();
			}
			else
			{
				// get list from DeepLoaded entity
				list = EntityUtil.GetEntityList(entity, listPropertyName);
			}

			return list;
		}

		/// <summary>
		/// Inserts any previously cached business object references.
		/// </summary>
		/// <param name="member">The relationship member.</param>
		private void Insert(EntityRelationshipMember member)
		{
			
			if ( member != null && member.HasDataSource )
			{
				Object entityKeyValue = PrimaryMember.GetEntityId();

				foreach ( IDictionary values in member.Inserts )
				{
					values[member.EntityKeyName] = entityKeyValue;
					member.GetLinkedDataSource().Insert(values);
				}

				member.Inserts.Clear();
			}
		}

		/// <summary>
		/// Inserts the specified name/value pairs into the
		/// relationship defined by the specified member.
		/// </summary>
		/// <param name="member">The relationship member.</param>
		/// <param name="links">A collection of business objects.</param>
		/// <param name="values">A collection of name/value pairs to insert.</param>
		private void Insert(EntityRelationshipMember member, IList links, IDictionary values)
		{
			Insert(member, links, values, false);
		}

		/// <summary>
		/// Inserts the specified name/value pairs into the
		/// relationship defined by the specified member.
		/// </summary>
		/// <param name="member">The relationship member.</param>
		/// <param name="links">A collection of business objects.</param>
		/// <param name="values">A collection of name/value pairs to insert.</param>
		/// <param name="initEntityKey">A value indicating whether or not to initialize the
		/// business object's unique identifier property before executing the insert operation.</param>
		private void Insert(EntityRelationshipMember member, IList links, IDictionary values, bool initEntityKey)
		{
			if ( member != null && member.HasDataSource )
			{
				member.GetLinkedDataSource().Insert(values);
			}
			else
			{
				Object link = EntityUtil.GetNewEntity(member.EntityType);
				EntityUtil.SetEntityValues(link, values);

				if ( initEntityKey )
				{
					EntityUtil.SetEntityKeyValue(link, member.EntityKeyName);
				}

				EntityUtil.Add(links, link);
			}
		}

		/// <summary>
		/// Updates the specified business object with the specified name/value pairs.
		/// </summary>
		/// <param name="member">The relationship member.</param>
		/// <param name="link">The business object to update.</param>
		/// <param name="values">A collection of name/value pairs to insert.</param>
		private void Update(EntityRelationshipMember member, Object link, IDictionary values)
		{
			if ( member != null && member.HasDataSource )
			{
				member.GetLinkedDataSource().Update(link, values);
			}
			else
			{
				EntityUtil.SetEntityValues(link, values);
			}
		}

		/// <summary>
		/// Removes the specified item from the collection of business objects.
		/// </summary>
		/// <param name="member">The relationship member.</param>
		/// <param name="links">A collection of business objects.</param>
		/// <param name="link">The item to remove.</param>
		private void Remove(EntityRelationshipMember member, IList links, Object link)
		{
			EntityUtil.Remove(links, link);

			if ( member != null && member.HasDataSource )
			{
				member.GetLinkedDataSource().Delete(link);
			}
		}

		#endregion

		#endregion
	}
}

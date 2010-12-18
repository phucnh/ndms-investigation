using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace NDMSInvestigation.Web.UI
{
    /// <summary>
    /// A designer class for a strongly typed repeater <c>AspnetMembershipRepeater</c>
    /// </summary>
	public class AspnetMembershipRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:AspnetMembershipRepeaterDesigner"/> class.
        /// </summary>
		public AspnetMembershipRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is AspnetMembershipRepeater))
			{ 
				throw new ArgumentException("Component is not a AspnetMembershipRepeater."); 
			} 
			base.Initialize(component); 
			base.SetViewFlags(ViewFlags.TemplateEditing, true); 
		}


		/// <summary>
		/// Generate HTML for the designer
		/// </summary>
		/// <returns>a string of design time HTML</returns>
		public override string GetDesignTimeHtml()
		{

			// Get the instance this designer applies to
			//
			AspnetMembershipRepeater z = (AspnetMembershipRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();

			//return z.RenderAtDesignTime();

			//	ControlCollection c = z.Controls;
			//Totem z = (Totem) Component;
			//Totem z = (Totem) Component;
			//return ("<div style='border: 1px gray dotted; background-color: lightgray'><b>TagStat :</b> zae |  qsdds</div>");

		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <c cref="AspnetMembershipRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(AspnetMembershipRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:AspnetMembershipRepeater runat=\"server\"></{0}:AspnetMembershipRepeater>")]
	public class AspnetMembershipRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:AspnetMembershipRepeater"/> class.
        /// </summary>
		public AspnetMembershipRepeater()
		{
		}

		/// <summary>
        /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of child controls for the specified server control.</returns>
		public override ControlCollection Controls
		{
			get
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		private ITemplate m_headerTemplate;
		/// <summary>
        /// Gets or sets the header template.
        /// </summary>
        /// <value>The header template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(AspnetMembershipItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate HeaderTemplate
		{
			get { return m_headerTemplate; }
			set { m_headerTemplate = value; }
		}

		private ITemplate m_itemTemplate;
		/// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(AspnetMembershipItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}

		private ITemplate m_seperatorTemplate;
        /// <summary>
        /// Gets or sets the Seperator Template
        /// </summary>
        [Browsable(false)]
        [TemplateContainer(typeof(AspnetMembershipItem))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public ITemplate SeperatorTemplate
        {
            get { return m_seperatorTemplate; }
            set { m_seperatorTemplate = value; }
        }
			
		private ITemplate m_altenateItemTemplate;
        /// <summary>
        /// Gets or sets the alternating item template.
        /// </summary>
        /// <value>The alternating item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(AspnetMembershipItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate AlternatingItemTemplate
		{
			get { return m_altenateItemTemplate; }
			set { m_altenateItemTemplate = value; }
		}

		private ITemplate m_footerTemplate;
        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        /// <value>The footer template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(AspnetMembershipItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}

//      /// <summary>
//      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
//      /// </summary>
//		protected override void CreateChildControls()
//      {
//         if (ChildControlsCreated)
//         {
//            return;
//         }

//         Controls.Clear();

//         //Instantiate the Header template (if exists)
//         if (m_headerTemplate != null)
//         {
//            Control headerItem = new Control();
//            m_headerTemplate.InstantiateIn(headerItem);
//            Controls.Add(headerItem);
//         }

//         //Instantiate the Footer template (if exists)
//         if (m_footerTemplate != null)
//         {
//            Control footerItem = new Control();
//            m_footerTemplate.InstantiateIn(footerItem);
//            Controls.Add(footerItem);
//         }
//
//         ChildControlsCreated = true;
//      }
	
		/// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            
        }

        /// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
                
        }		
		
		/// <summary>
      	/// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
      	/// </summary>
		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
      	{
         int pos = 0;

         if (dataBinding)
         {
            //Instantiate the Header template (if exists)
            if (m_headerTemplate != null)
            {
                Control headerItem = new Control();
                m_headerTemplate.InstantiateIn(headerItem);
                Controls.Add(headerItem);
            }
			if (dataSource != null)
			{
				foreach (object o in dataSource)
				{
						NDMSInvestigation.Entities.AspnetMembership entity = o as NDMSInvestigation.Entities.AspnetMembership;
						AspnetMembershipItem container = new AspnetMembershipItem(entity);
	
						if (m_itemTemplate != null && (pos % 2) == 0)
						{
							m_itemTemplate.InstantiateIn(container);
							
							if (m_seperatorTemplate != null)
							{
								m_seperatorTemplate.InstantiateIn(container);
							}
						}
						else
						{
							if (m_altenateItemTemplate != null)
							{
								m_altenateItemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
								
							}
							else if (m_itemTemplate != null)
							{
								m_itemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
							}
							else
							{
								// no template !!!
							}
						}
						Controls.Add(container);
						
						container.DataBind();
						
						pos++;
				}
			}
            //Instantiate the Footer template (if exists)
            if (m_footerTemplate != null)
            {
                Control footerItem = new Control();
                m_footerTemplate.InstantiateIn(footerItem);
                Controls.Add(footerItem);
            }

		}
			
			return pos;
		}

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.DataBind();
		}

		#region Design time
        /// <summary>
        /// Renders at design time.
        /// </summary>
        /// <returns>a  string of the Designed HTML</returns>
		internal string RenderAtDesignTime()
		{			
			return "Designer currently not implemented"; 
		}

		#endregion
	}

    /// <summary>
    /// A wrapper type for the entity
    /// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	public class AspnetMembershipItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private NDMSInvestigation.Entities.AspnetMembership _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AspnetMembershipItem"/> class.
        /// </summary>
		public AspnetMembershipItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AspnetMembershipItem"/> class.
        /// </summary>
		public AspnetMembershipItem(NDMSInvestigation.Entities.AspnetMembership entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the ApplicationId
        /// </summary>
        /// <value>The ApplicationId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Guid ApplicationId
		{
			get { return _entity.ApplicationId; }
		}
        /// <summary>
        /// Gets the UserId
        /// </summary>
        /// <value>The UserId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Guid UserId
		{
			get { return _entity.UserId; }
		}
        /// <summary>
        /// Gets the Password
        /// </summary>
        /// <value>The Password.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Password
		{
			get { return _entity.Password; }
		}
        /// <summary>
        /// Gets the PasswordFormat
        /// </summary>
        /// <value>The PasswordFormat.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 PasswordFormat
		{
			get { return _entity.PasswordFormat; }
		}
        /// <summary>
        /// Gets the PasswordSalt
        /// </summary>
        /// <value>The PasswordSalt.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PasswordSalt
		{
			get { return _entity.PasswordSalt; }
		}
        /// <summary>
        /// Gets the MobilePin
        /// </summary>
        /// <value>The MobilePin.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MobilePin
		{
			get { return _entity.MobilePin; }
		}
        /// <summary>
        /// Gets the Email
        /// </summary>
        /// <value>The Email.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Email
		{
			get { return _entity.Email; }
		}
        /// <summary>
        /// Gets the LoweredEmail
        /// </summary>
        /// <value>The LoweredEmail.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LoweredEmail
		{
			get { return _entity.LoweredEmail; }
		}
        /// <summary>
        /// Gets the PasswordQuestion
        /// </summary>
        /// <value>The PasswordQuestion.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PasswordQuestion
		{
			get { return _entity.PasswordQuestion; }
		}
        /// <summary>
        /// Gets the PasswordAnswer
        /// </summary>
        /// <value>The PasswordAnswer.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PasswordAnswer
		{
			get { return _entity.PasswordAnswer; }
		}
        /// <summary>
        /// Gets the IsApproved
        /// </summary>
        /// <value>The IsApproved.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean IsApproved
		{
			get { return _entity.IsApproved; }
		}
        /// <summary>
        /// Gets the IsLockedOut
        /// </summary>
        /// <value>The IsLockedOut.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean IsLockedOut
		{
			get { return _entity.IsLockedOut; }
		}
        /// <summary>
        /// Gets the CreateDate
        /// </summary>
        /// <value>The CreateDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime CreateDate
		{
			get { return _entity.CreateDate; }
		}
        /// <summary>
        /// Gets the LastLoginDate
        /// </summary>
        /// <value>The LastLoginDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime LastLoginDate
		{
			get { return _entity.LastLoginDate; }
		}
        /// <summary>
        /// Gets the LastPasswordChangedDate
        /// </summary>
        /// <value>The LastPasswordChangedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime LastPasswordChangedDate
		{
			get { return _entity.LastPasswordChangedDate; }
		}
        /// <summary>
        /// Gets the LastLockoutDate
        /// </summary>
        /// <value>The LastLockoutDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime LastLockoutDate
		{
			get { return _entity.LastLockoutDate; }
		}
        /// <summary>
        /// Gets the FailedPasswordAttemptCount
        /// </summary>
        /// <value>The FailedPasswordAttemptCount.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 FailedPasswordAttemptCount
		{
			get { return _entity.FailedPasswordAttemptCount; }
		}
        /// <summary>
        /// Gets the FailedPasswordAttemptWindowStart
        /// </summary>
        /// <value>The FailedPasswordAttemptWindowStart.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime FailedPasswordAttemptWindowStart
		{
			get { return _entity.FailedPasswordAttemptWindowStart; }
		}
        /// <summary>
        /// Gets the FailedPasswordAnswerAttemptCount
        /// </summary>
        /// <value>The FailedPasswordAnswerAttemptCount.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 FailedPasswordAnswerAttemptCount
		{
			get { return _entity.FailedPasswordAnswerAttemptCount; }
		}
        /// <summary>
        /// Gets the FailedPasswordAnswerAttemptWindowStart
        /// </summary>
        /// <value>The FailedPasswordAnswerAttemptWindowStart.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime FailedPasswordAnswerAttemptWindowStart
		{
			get { return _entity.FailedPasswordAnswerAttemptWindowStart; }
		}
        /// <summary>
        /// Gets the Comment
        /// </summary>
        /// <value>The Comment.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Comment
		{
			get { return _entity.Comment; }
		}

        /// <summary>
        /// Gets a <see cref="T:NDMSInvestigation.Entities.AspnetMembership"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public NDMSInvestigation.Entities.AspnetMembership Entity
        {
            get { return _entity; }
        }
	}
}

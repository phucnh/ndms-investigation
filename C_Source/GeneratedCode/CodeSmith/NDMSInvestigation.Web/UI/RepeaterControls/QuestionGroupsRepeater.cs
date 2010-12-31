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
    /// A designer class for a strongly typed repeater <c>QuestionGroupsRepeater</c>
    /// </summary>
	public class QuestionGroupsRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:QuestionGroupsRepeaterDesigner"/> class.
        /// </summary>
		public QuestionGroupsRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is QuestionGroupsRepeater))
			{ 
				throw new ArgumentException("Component is not a QuestionGroupsRepeater."); 
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
			QuestionGroupsRepeater z = (QuestionGroupsRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="QuestionGroupsRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(QuestionGroupsRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:QuestionGroupsRepeater runat=\"server\"></{0}:QuestionGroupsRepeater>")]
	public class QuestionGroupsRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:QuestionGroupsRepeater"/> class.
        /// </summary>
		public QuestionGroupsRepeater()
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
		[TemplateContainer(typeof(QuestionGroupsItem))]
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
		[TemplateContainer(typeof(QuestionGroupsItem))]
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
        [TemplateContainer(typeof(QuestionGroupsItem))]
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
		[TemplateContainer(typeof(QuestionGroupsItem))]
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
		[TemplateContainer(typeof(QuestionGroupsItem))]
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
						NDMSInvestigation.Entities.QuestionGroups entity = o as NDMSInvestigation.Entities.QuestionGroups;
						QuestionGroupsItem container = new QuestionGroupsItem(entity);
	
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
	public class QuestionGroupsItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private NDMSInvestigation.Entities.QuestionGroups _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuestionGroupsItem"/> class.
        /// </summary>
		public QuestionGroupsItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuestionGroupsItem"/> class.
        /// </summary>
		public QuestionGroupsItem(NDMSInvestigation.Entities.QuestionGroups entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the GroupId
        /// </summary>
        /// <value>The GroupId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 GroupId
		{
			get { return _entity.GroupId; }
		}
        /// <summary>
        /// Gets the GroupName
        /// </summary>
        /// <value>The GroupName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String GroupName
		{
			get { return _entity.GroupName; }
		}
        /// <summary>
        /// Gets the GroupDescription
        /// </summary>
        /// <value>The GroupDescription.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String GroupDescription
		{
			get { return _entity.GroupDescription; }
		}
        /// <summary>
        /// Gets the OrderNumber
        /// </summary>
        /// <value>The OrderNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? OrderNumber
		{
			get { return _entity.OrderNumber; }
		}
        /// <summary>
        /// Gets the CreatedDate
        /// </summary>
        /// <value>The CreatedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? CreatedDate
		{
			get { return _entity.CreatedDate; }
		}
        /// <summary>
        /// Gets the CreatedBy
        /// </summary>
        /// <value>The CreatedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CreatedBy
		{
			get { return _entity.CreatedBy; }
		}
        /// <summary>
        /// Gets the UpdatedDate
        /// </summary>
        /// <value>The UpdatedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? UpdatedDate
		{
			get { return _entity.UpdatedDate; }
		}
        /// <summary>
        /// Gets the UpdatedBy
        /// </summary>
        /// <value>The UpdatedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String UpdatedBy
		{
			get { return _entity.UpdatedBy; }
		}

        /// <summary>
        /// Gets a <see cref="T:NDMSInvestigation.Entities.QuestionGroups"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public NDMSInvestigation.Entities.QuestionGroups Entity
        {
            get { return _entity; }
        }
	}
}

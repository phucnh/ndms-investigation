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
    /// A designer class for a strongly typed repeater <c>CompanyDetailsRepeater</c>
    /// </summary>
	public class CompanyDetailsRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:CompanyDetailsRepeaterDesigner"/> class.
        /// </summary>
		public CompanyDetailsRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is CompanyDetailsRepeater))
			{ 
				throw new ArgumentException("Component is not a CompanyDetailsRepeater."); 
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
			CompanyDetailsRepeater z = (CompanyDetailsRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="CompanyDetailsRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(CompanyDetailsRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:CompanyDetailsRepeater runat=\"server\"></{0}:CompanyDetailsRepeater>")]
	public class CompanyDetailsRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:CompanyDetailsRepeater"/> class.
        /// </summary>
		public CompanyDetailsRepeater()
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
		[TemplateContainer(typeof(CompanyDetailsItem))]
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
		[TemplateContainer(typeof(CompanyDetailsItem))]
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
        [TemplateContainer(typeof(CompanyDetailsItem))]
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
		[TemplateContainer(typeof(CompanyDetailsItem))]
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
		[TemplateContainer(typeof(CompanyDetailsItem))]
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
						NDMSInvestigation.Entities.CompanyDetails entity = o as NDMSInvestigation.Entities.CompanyDetails;
						CompanyDetailsItem container = new CompanyDetailsItem(entity);
	
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
	public class CompanyDetailsItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private NDMSInvestigation.Entities.CompanyDetails _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CompanyDetailsItem"/> class.
        /// </summary>
		public CompanyDetailsItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CompanyDetailsItem"/> class.
        /// </summary>
		public CompanyDetailsItem(NDMSInvestigation.Entities.CompanyDetails entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the CompanyId
        /// </summary>
        /// <value>The CompanyId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 CompanyId
		{
			get { return _entity.CompanyId; }
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
        /// Gets the CompanyName
        /// </summary>
        /// <value>The CompanyName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CompanyName
		{
			get { return _entity.CompanyName; }
		}
        /// <summary>
        /// Gets the Phone
        /// </summary>
        /// <value>The Phone.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Phone
		{
			get { return _entity.Phone; }
		}
        /// <summary>
        /// Gets the Fax
        /// </summary>
        /// <value>The Fax.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Fax
		{
			get { return _entity.Fax; }
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
        /// Gets the Address
        /// </summary>
        /// <value>The Address.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Address
		{
			get { return _entity.Address; }
		}
        /// <summary>
        /// Gets the EmployeeNumber
        /// </summary>
        /// <value>The EmployeeNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? EmployeeNumber
		{
			get { return _entity.EmployeeNumber; }
		}
        /// <summary>
        /// Gets the Director
        /// </summary>
        /// <value>The Director.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Director
		{
			get { return _entity.Director; }
		}
        /// <summary>
        /// Gets the Country
        /// </summary>
        /// <value>The Country.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Country
		{
			get { return _entity.Country; }
		}
        /// <summary>
        /// Gets the City
        /// </summary>
        /// <value>The City.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String City
		{
			get { return _entity.City; }
		}
        /// <summary>
        /// Gets the District
        /// </summary>
        /// <value>The District.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String District
		{
			get { return _entity.District; }
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
        /// Gets the UpdatedDate
        /// </summary>
        /// <value>The UpdatedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? UpdatedDate
		{
			get { return _entity.UpdatedDate; }
		}
        /// <summary>
        /// Gets the Description
        /// </summary>
        /// <value>The Description.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Description
		{
			get { return _entity.Description; }
		}
        /// <summary>
        /// Gets the CurrentTotalMark
        /// </summary>
        /// <value>The CurrentTotalMark.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? CurrentTotalMark
		{
			get { return _entity.CurrentTotalMark; }
		}
        /// <summary>
        /// Gets the TraceChange
        /// </summary>
        /// <value>The TraceChange.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? TraceChange
		{
			get { return _entity.TraceChange; }
		}

        /// <summary>
        /// Gets a <see cref="T:NDMSInvestigation.Entities.CompanyDetails"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public NDMSInvestigation.Entities.CompanyDetails Entity
        {
            get { return _entity; }
        }
	}
}

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
    /// A designer class for a strongly typed repeater <c>AspnetWebEventEventsRepeater</c>
    /// </summary>
	public class AspnetWebEventEventsRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:AspnetWebEventEventsRepeaterDesigner"/> class.
        /// </summary>
		public AspnetWebEventEventsRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is AspnetWebEventEventsRepeater))
			{ 
				throw new ArgumentException("Component is not a AspnetWebEventEventsRepeater."); 
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
			AspnetWebEventEventsRepeater z = (AspnetWebEventEventsRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="AspnetWebEventEventsRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(AspnetWebEventEventsRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:AspnetWebEventEventsRepeater runat=\"server\"></{0}:AspnetWebEventEventsRepeater>")]
	public class AspnetWebEventEventsRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:AspnetWebEventEventsRepeater"/> class.
        /// </summary>
		public AspnetWebEventEventsRepeater()
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
		[TemplateContainer(typeof(AspnetWebEventEventsItem))]
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
		[TemplateContainer(typeof(AspnetWebEventEventsItem))]
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
        [TemplateContainer(typeof(AspnetWebEventEventsItem))]
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
		[TemplateContainer(typeof(AspnetWebEventEventsItem))]
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
		[TemplateContainer(typeof(AspnetWebEventEventsItem))]
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
						NDMSInvestigation.Entities.AspnetWebEventEvents entity = o as NDMSInvestigation.Entities.AspnetWebEventEvents;
						AspnetWebEventEventsItem container = new AspnetWebEventEventsItem(entity);
	
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
	public class AspnetWebEventEventsItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private NDMSInvestigation.Entities.AspnetWebEventEvents _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AspnetWebEventEventsItem"/> class.
        /// </summary>
		public AspnetWebEventEventsItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AspnetWebEventEventsItem"/> class.
        /// </summary>
		public AspnetWebEventEventsItem(NDMSInvestigation.Entities.AspnetWebEventEvents entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the EventId
        /// </summary>
        /// <value>The EventId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EventId
		{
			get { return _entity.EventId; }
		}
        /// <summary>
        /// Gets the EventTimeUtc
        /// </summary>
        /// <value>The EventTimeUtc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime EventTimeUtc
		{
			get { return _entity.EventTimeUtc; }
		}
        /// <summary>
        /// Gets the EventTime
        /// </summary>
        /// <value>The EventTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime EventTime
		{
			get { return _entity.EventTime; }
		}
        /// <summary>
        /// Gets the EventType
        /// </summary>
        /// <value>The EventType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EventType
		{
			get { return _entity.EventType; }
		}
        /// <summary>
        /// Gets the EventSequence
        /// </summary>
        /// <value>The EventSequence.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal EventSequence
		{
			get { return _entity.EventSequence; }
		}
        /// <summary>
        /// Gets the EventOccurrence
        /// </summary>
        /// <value>The EventOccurrence.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal EventOccurrence
		{
			get { return _entity.EventOccurrence; }
		}
        /// <summary>
        /// Gets the EventCode
        /// </summary>
        /// <value>The EventCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 EventCode
		{
			get { return _entity.EventCode; }
		}
        /// <summary>
        /// Gets the EventDetailCode
        /// </summary>
        /// <value>The EventDetailCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 EventDetailCode
		{
			get { return _entity.EventDetailCode; }
		}
        /// <summary>
        /// Gets the Message
        /// </summary>
        /// <value>The Message.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Message
		{
			get { return _entity.Message; }
		}
        /// <summary>
        /// Gets the ApplicationPath
        /// </summary>
        /// <value>The ApplicationPath.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ApplicationPath
		{
			get { return _entity.ApplicationPath; }
		}
        /// <summary>
        /// Gets the ApplicationVirtualPath
        /// </summary>
        /// <value>The ApplicationVirtualPath.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ApplicationVirtualPath
		{
			get { return _entity.ApplicationVirtualPath; }
		}
        /// <summary>
        /// Gets the MachineName
        /// </summary>
        /// <value>The MachineName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MachineName
		{
			get { return _entity.MachineName; }
		}
        /// <summary>
        /// Gets the RequestUrl
        /// </summary>
        /// <value>The RequestUrl.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RequestUrl
		{
			get { return _entity.RequestUrl; }
		}
        /// <summary>
        /// Gets the ExceptionType
        /// </summary>
        /// <value>The ExceptionType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ExceptionType
		{
			get { return _entity.ExceptionType; }
		}
        /// <summary>
        /// Gets the Details
        /// </summary>
        /// <value>The Details.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Details
		{
			get { return _entity.Details; }
		}

        /// <summary>
        /// Gets a <see cref="T:NDMSInvestigation.Entities.AspnetWebEventEvents"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public NDMSInvestigation.Entities.AspnetWebEventEvents Entity
        {
            get { return _entity; }
        }
	}
}

namespace DBCompare
{
    partial class ObjectCompare
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectCompare));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkRoutes = new System.Windows.Forms.CheckBox();
            this.chkPartitionFunctions = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkApplicationRoles = new System.Windows.Forms.CheckBox();
            this.chkUserDefinedTableTypes = new System.Windows.Forms.CheckBox();
            this.chkDatabaseRoles = new System.Windows.Forms.CheckBox();
            this.chkFullTextStopLists = new System.Windows.Forms.CheckBox();
            this.chkDefaults = new System.Windows.Forms.CheckBox();
            this.chkFullTextCatalogs = new System.Windows.Forms.CheckBox();
            this.chkMessageTypes = new System.Windows.Forms.CheckBox();
            this.chkPartitionSchemes = new System.Windows.Forms.CheckBox();
            this.chkPlanGuides = new System.Windows.Forms.CheckBox();
            this.chkRemoteServiceBindings = new System.Windows.Forms.CheckBox();
            this.chkRules = new System.Windows.Forms.CheckBox();
            this.chkServiceContracts = new System.Windows.Forms.CheckBox();
            this.chkSchemas = new System.Windows.Forms.CheckBox();
            this.chkQueues = new System.Windows.Forms.CheckBox();
            this.chkAssemblies = new System.Windows.Forms.CheckBox();
            this.chkStoredProcedures = new System.Windows.Forms.CheckBox();
            this.chkTriggers = new System.Windows.Forms.CheckBox();
            this.chkViews = new System.Windows.Forms.CheckBox();
            this.chkSynonyms = new System.Windows.Forms.CheckBox();
            this.chkTables = new System.Windows.Forms.CheckBox();
            this.chkUsers = new System.Windows.Forms.CheckBox();
            this.chkUserDefinedAggregates = new System.Windows.Forms.CheckBox();
            this.chkUserDefinedTypes = new System.Windows.Forms.CheckBox();
            this.chkUserDefinedFunctions = new System.Windows.Forms.CheckBox();
            this.chkUserDefinedDataTypes = new System.Windows.Forms.CheckBox();
            this.chkXmlSchemaCollections = new System.Windows.Forms.CheckBox();
            this.chkIndexes = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.chkCLRTriggers = new System.Windows.Forms.CheckBox();
            this.chkDMLTriggers = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lwDatabaseObjects = new System.Windows.Forms.ListView();
            this.clmType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSchema = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilIcons = new System.Windows.Forms.ImageList(this.components);
            this.lvDestination = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSource = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.btnFromDB1ToDB2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFromDB2ToDB1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chkCLRDMLTriggers = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.chkAll);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(987, 732);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.chkRoutes, 0, 23);
            this.tableLayoutPanel1.Controls.Add(this.chkPartitionFunctions, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnRefresh, 0, 49);
            this.tableLayoutPanel1.Controls.Add(this.chkApplicationRoles, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkUserDefinedTableTypes, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkDatabaseRoles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkFullTextStopLists, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkDefaults, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkFullTextCatalogs, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkMessageTypes, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.chkPartitionSchemes, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.chkPlanGuides, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.chkRemoteServiceBindings, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.chkRules, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.chkServiceContracts, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.chkSchemas, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.chkQueues, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.chkAssemblies, 0, 24);
            this.tableLayoutPanel1.Controls.Add(this.chkStoredProcedures, 0, 25);
            this.tableLayoutPanel1.Controls.Add(this.chkTriggers, 0, 26);
            this.tableLayoutPanel1.Controls.Add(this.chkViews, 0, 27);
            this.tableLayoutPanel1.Controls.Add(this.chkSynonyms, 0, 28);
            this.tableLayoutPanel1.Controls.Add(this.chkTables, 0, 29);
            this.tableLayoutPanel1.Controls.Add(this.chkUsers, 0, 30);
            this.tableLayoutPanel1.Controls.Add(this.chkUserDefinedAggregates, 0, 34);
            this.tableLayoutPanel1.Controls.Add(this.chkUserDefinedTypes, 0, 35);
            this.tableLayoutPanel1.Controls.Add(this.chkUserDefinedFunctions, 0, 36);
            this.tableLayoutPanel1.Controls.Add(this.chkUserDefinedDataTypes, 0, 37);
            this.tableLayoutPanel1.Controls.Add(this.chkXmlSchemaCollections, 0, 38);
            this.tableLayoutPanel1.Controls.Add(this.chkIndexes, 0, 40);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 0, 41);
            this.tableLayoutPanel1.Controls.Add(this.checkBox2, 0, 42);
            this.tableLayoutPanel1.Controls.Add(this.checkBox3, 0, 43);
            this.tableLayoutPanel1.Controls.Add(this.checkBox4, 0, 44);
            this.tableLayoutPanel1.Controls.Add(this.chkCLRTriggers, 0, 45);
            this.tableLayoutPanel1.Controls.Add(this.chkDMLTriggers, 0, 47);
            this.tableLayoutPanel1.Controls.Add(this.chkCLRDMLTriggers, 0, 46);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 50;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(224, 859);
            this.tableLayoutPanel1.TabIndex = 7;
            this.tableLayoutPanel1.Tag = "Index";
            // 
            // chkRoutes
            // 
            this.chkRoutes.AutoSize = true;
            this.chkRoutes.Checked = true;
            this.chkRoutes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRoutes.Location = new System.Drawing.Point(3, 348);
            this.chkRoutes.Name = "chkRoutes";
            this.chkRoutes.Size = new System.Drawing.Size(60, 17);
            this.chkRoutes.TabIndex = 16;
            this.chkRoutes.Tag = "ServiceRoute";
            this.chkRoutes.Text = "Routes";
            this.chkRoutes.UseVisualStyleBackColor = true;
            // 
            // chkPartitionFunctions
            // 
            this.chkPartitionFunctions.AutoSize = true;
            this.chkPartitionFunctions.Checked = true;
            this.chkPartitionFunctions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPartitionFunctions.Location = new System.Drawing.Point(3, 164);
            this.chkPartitionFunctions.Name = "chkPartitionFunctions";
            this.chkPartitionFunctions.Size = new System.Drawing.Size(113, 17);
            this.chkPartitionFunctions.TabIndex = 8;
            this.chkPartitionFunctions.Tag = "PartitionFunction";
            this.chkPartitionFunctions.Text = "Partition Functions";
            this.chkPartitionFunctions.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(3, 831);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 30;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // chkApplicationRoles
            // 
            this.chkApplicationRoles.AutoSize = true;
            this.chkApplicationRoles.Checked = true;
            this.chkApplicationRoles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApplicationRoles.Location = new System.Drawing.Point(3, 3);
            this.chkApplicationRoles.Name = "chkApplicationRoles";
            this.chkApplicationRoles.Size = new System.Drawing.Size(108, 17);
            this.chkApplicationRoles.TabIndex = 1;
            this.chkApplicationRoles.Tag = "ApplicationRole";
            this.chkApplicationRoles.Text = "Application Roles";
            this.chkApplicationRoles.UseVisualStyleBackColor = true;
            // 
            // chkUserDefinedTableTypes
            // 
            this.chkUserDefinedTableTypes.AutoSize = true;
            this.chkUserDefinedTableTypes.Checked = true;
            this.chkUserDefinedTableTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserDefinedTableTypes.Location = new System.Drawing.Point(3, 118);
            this.chkUserDefinedTableTypes.Name = "chkUserDefinedTableTypes";
            this.chkUserDefinedTableTypes.Size = new System.Drawing.Size(150, 17);
            this.chkUserDefinedTableTypes.TabIndex = 6;
            this.chkUserDefinedTableTypes.Tag = "UserDefinedTableType";
            this.chkUserDefinedTableTypes.Text = "User Defined Table Types";
            this.chkUserDefinedTableTypes.UseVisualStyleBackColor = true;
            // 
            // chkDatabaseRoles
            // 
            this.chkDatabaseRoles.AutoSize = true;
            this.chkDatabaseRoles.Checked = true;
            this.chkDatabaseRoles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDatabaseRoles.Location = new System.Drawing.Point(3, 26);
            this.chkDatabaseRoles.Name = "chkDatabaseRoles";
            this.chkDatabaseRoles.Size = new System.Drawing.Size(102, 17);
            this.chkDatabaseRoles.TabIndex = 2;
            this.chkDatabaseRoles.Tag = "DatabaseRole";
            this.chkDatabaseRoles.Text = "Database Roles";
            this.chkDatabaseRoles.UseVisualStyleBackColor = true;
            // 
            // chkFullTextStopLists
            // 
            this.chkFullTextStopLists.AutoSize = true;
            this.chkFullTextStopLists.Checked = true;
            this.chkFullTextStopLists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFullTextStopLists.Location = new System.Drawing.Point(3, 95);
            this.chkFullTextStopLists.Name = "chkFullTextStopLists";
            this.chkFullTextStopLists.Size = new System.Drawing.Size(112, 17);
            this.chkFullTextStopLists.TabIndex = 5;
            this.chkFullTextStopLists.Tag = "FullTextStopList";
            this.chkFullTextStopLists.Text = "FullText Stop Lists";
            this.chkFullTextStopLists.UseVisualStyleBackColor = true;
            // 
            // chkDefaults
            // 
            this.chkDefaults.AutoSize = true;
            this.chkDefaults.Checked = true;
            this.chkDefaults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefaults.Location = new System.Drawing.Point(3, 49);
            this.chkDefaults.Name = "chkDefaults";
            this.chkDefaults.Size = new System.Drawing.Size(65, 17);
            this.chkDefaults.TabIndex = 3;
            this.chkDefaults.Tag = "Default";
            this.chkDefaults.Text = "Defaults";
            this.chkDefaults.UseVisualStyleBackColor = true;
            // 
            // chkFullTextCatalogs
            // 
            this.chkFullTextCatalogs.AutoSize = true;
            this.chkFullTextCatalogs.Checked = true;
            this.chkFullTextCatalogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFullTextCatalogs.Location = new System.Drawing.Point(3, 72);
            this.chkFullTextCatalogs.Name = "chkFullTextCatalogs";
            this.chkFullTextCatalogs.Size = new System.Drawing.Size(107, 17);
            this.chkFullTextCatalogs.TabIndex = 4;
            this.chkFullTextCatalogs.Tag = "FullTextCatalog";
            this.chkFullTextCatalogs.Text = "FullText Catalogs";
            this.chkFullTextCatalogs.UseVisualStyleBackColor = true;
            // 
            // chkMessageTypes
            // 
            this.chkMessageTypes.AutoSize = true;
            this.chkMessageTypes.Checked = true;
            this.chkMessageTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMessageTypes.Location = new System.Drawing.Point(3, 141);
            this.chkMessageTypes.Name = "chkMessageTypes";
            this.chkMessageTypes.Size = new System.Drawing.Size(101, 17);
            this.chkMessageTypes.TabIndex = 7;
            this.chkMessageTypes.Tag = "MessageType";
            this.chkMessageTypes.Text = "Message Types";
            this.chkMessageTypes.UseVisualStyleBackColor = true;
            // 
            // chkPartitionSchemes
            // 
            this.chkPartitionSchemes.AutoSize = true;
            this.chkPartitionSchemes.Checked = true;
            this.chkPartitionSchemes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPartitionSchemes.Location = new System.Drawing.Point(3, 187);
            this.chkPartitionSchemes.Name = "chkPartitionSchemes";
            this.chkPartitionSchemes.Size = new System.Drawing.Size(111, 17);
            this.chkPartitionSchemes.TabIndex = 9;
            this.chkPartitionSchemes.Tag = "PartitionScheme";
            this.chkPartitionSchemes.Text = "Partition Schemes";
            this.chkPartitionSchemes.UseVisualStyleBackColor = true;
            // 
            // chkPlanGuides
            // 
            this.chkPlanGuides.AutoSize = true;
            this.chkPlanGuides.Checked = true;
            this.chkPlanGuides.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPlanGuides.Location = new System.Drawing.Point(3, 210);
            this.chkPlanGuides.Name = "chkPlanGuides";
            this.chkPlanGuides.Size = new System.Drawing.Size(83, 17);
            this.chkPlanGuides.TabIndex = 10;
            this.chkPlanGuides.Tag = "PlanGuide";
            this.chkPlanGuides.Text = "Plan Guides";
            this.chkPlanGuides.UseVisualStyleBackColor = true;
            // 
            // chkRemoteServiceBindings
            // 
            this.chkRemoteServiceBindings.AutoSize = true;
            this.chkRemoteServiceBindings.Checked = true;
            this.chkRemoteServiceBindings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoteServiceBindings.Location = new System.Drawing.Point(3, 233);
            this.chkRemoteServiceBindings.Name = "chkRemoteServiceBindings";
            this.chkRemoteServiceBindings.Size = new System.Drawing.Size(145, 17);
            this.chkRemoteServiceBindings.TabIndex = 11;
            this.chkRemoteServiceBindings.Tag = "RemoteServiceBinding";
            this.chkRemoteServiceBindings.Text = "Remote Service Bindings";
            this.chkRemoteServiceBindings.UseVisualStyleBackColor = true;
            // 
            // chkRules
            // 
            this.chkRules.AutoSize = true;
            this.chkRules.Checked = true;
            this.chkRules.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRules.Location = new System.Drawing.Point(3, 256);
            this.chkRules.Name = "chkRules";
            this.chkRules.Size = new System.Drawing.Size(53, 17);
            this.chkRules.TabIndex = 12;
            this.chkRules.Tag = "Rule";
            this.chkRules.Text = "Rules";
            this.chkRules.UseVisualStyleBackColor = true;
            // 
            // chkServiceContracts
            // 
            this.chkServiceContracts.AutoSize = true;
            this.chkServiceContracts.Checked = true;
            this.chkServiceContracts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkServiceContracts.Location = new System.Drawing.Point(3, 302);
            this.chkServiceContracts.Name = "chkServiceContracts";
            this.chkServiceContracts.Size = new System.Drawing.Size(110, 17);
            this.chkServiceContracts.TabIndex = 14;
            this.chkServiceContracts.Tag = "ServiceContract";
            this.chkServiceContracts.Text = "Service Contracts";
            this.chkServiceContracts.UseVisualStyleBackColor = true;
            // 
            // chkSchemas
            // 
            this.chkSchemas.AutoSize = true;
            this.chkSchemas.Checked = true;
            this.chkSchemas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSchemas.Location = new System.Drawing.Point(3, 279);
            this.chkSchemas.Name = "chkSchemas";
            this.chkSchemas.Size = new System.Drawing.Size(70, 17);
            this.chkSchemas.TabIndex = 13;
            this.chkSchemas.Tag = "Schema";
            this.chkSchemas.Text = "Schemas";
            this.chkSchemas.UseVisualStyleBackColor = true;
            // 
            // chkQueues
            // 
            this.chkQueues.AutoSize = true;
            this.chkQueues.Checked = true;
            this.chkQueues.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkQueues.Location = new System.Drawing.Point(3, 325);
            this.chkQueues.Name = "chkQueues";
            this.chkQueues.Size = new System.Drawing.Size(63, 17);
            this.chkQueues.TabIndex = 15;
            this.chkQueues.Tag = "ServiceQueue";
            this.chkQueues.Text = "Queues";
            this.chkQueues.UseVisualStyleBackColor = true;
            // 
            // chkAssemblies
            // 
            this.chkAssemblies.AutoSize = true;
            this.chkAssemblies.Checked = true;
            this.chkAssemblies.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAssemblies.Location = new System.Drawing.Point(3, 371);
            this.chkAssemblies.Name = "chkAssemblies";
            this.chkAssemblies.Size = new System.Drawing.Size(78, 17);
            this.chkAssemblies.TabIndex = 17;
            this.chkAssemblies.Tag = "Assembly";
            this.chkAssemblies.Text = "Assemblies";
            this.chkAssemblies.UseVisualStyleBackColor = true;
            // 
            // chkStoredProcedures
            // 
            this.chkStoredProcedures.AutoSize = true;
            this.chkStoredProcedures.Checked = true;
            this.chkStoredProcedures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStoredProcedures.Location = new System.Drawing.Point(3, 394);
            this.chkStoredProcedures.Name = "chkStoredProcedures";
            this.chkStoredProcedures.Size = new System.Drawing.Size(114, 17);
            this.chkStoredProcedures.TabIndex = 18;
            this.chkStoredProcedures.Tag = "StoredProcedure";
            this.chkStoredProcedures.Text = "Stored Procedures";
            this.chkStoredProcedures.UseVisualStyleBackColor = true;
            // 
            // chkTriggers
            // 
            this.chkTriggers.AutoSize = true;
            this.chkTriggers.Checked = true;
            this.chkTriggers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTriggers.Location = new System.Drawing.Point(3, 417);
            this.chkTriggers.Name = "chkTriggers";
            this.chkTriggers.Size = new System.Drawing.Size(89, 17);
            this.chkTriggers.TabIndex = 19;
            this.chkTriggers.Tag = "SQLDDLTrigger";
            this.chkTriggers.Text = "DDL Triggers";
            this.chkTriggers.UseVisualStyleBackColor = true;
            // 
            // chkViews
            // 
            this.chkViews.AutoSize = true;
            this.chkViews.Checked = true;
            this.chkViews.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViews.Location = new System.Drawing.Point(3, 440);
            this.chkViews.Name = "chkViews";
            this.chkViews.Size = new System.Drawing.Size(54, 17);
            this.chkViews.TabIndex = 20;
            this.chkViews.Tag = "View";
            this.chkViews.Text = "Views";
            this.chkViews.UseVisualStyleBackColor = true;
            // 
            // chkSynonyms
            // 
            this.chkSynonyms.AutoSize = true;
            this.chkSynonyms.Checked = true;
            this.chkSynonyms.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSynonyms.Location = new System.Drawing.Point(3, 463);
            this.chkSynonyms.Name = "chkSynonyms";
            this.chkSynonyms.Size = new System.Drawing.Size(74, 17);
            this.chkSynonyms.TabIndex = 21;
            this.chkSynonyms.Tag = "Synonym";
            this.chkSynonyms.Text = "Synonyms";
            this.chkSynonyms.UseVisualStyleBackColor = true;
            // 
            // chkTables
            // 
            this.chkTables.AutoSize = true;
            this.chkTables.Checked = true;
            this.chkTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTables.Location = new System.Drawing.Point(3, 486);
            this.chkTables.Name = "chkTables";
            this.chkTables.Size = new System.Drawing.Size(58, 17);
            this.chkTables.TabIndex = 22;
            this.chkTables.Tag = "Table";
            this.chkTables.Text = "Tables";
            this.chkTables.UseVisualStyleBackColor = true;
            // 
            // chkUsers
            // 
            this.chkUsers.AutoSize = true;
            this.chkUsers.Checked = true;
            this.chkUsers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUsers.Location = new System.Drawing.Point(3, 509);
            this.chkUsers.Name = "chkUsers";
            this.chkUsers.Size = new System.Drawing.Size(53, 17);
            this.chkUsers.TabIndex = 23;
            this.chkUsers.Tag = "User";
            this.chkUsers.Text = "Users";
            this.chkUsers.UseVisualStyleBackColor = true;
            // 
            // chkUserDefinedAggregates
            // 
            this.chkUserDefinedAggregates.AutoSize = true;
            this.chkUserDefinedAggregates.Checked = true;
            this.chkUserDefinedAggregates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserDefinedAggregates.Location = new System.Drawing.Point(3, 532);
            this.chkUserDefinedAggregates.Name = "chkUserDefinedAggregates";
            this.chkUserDefinedAggregates.Size = new System.Drawing.Size(145, 17);
            this.chkUserDefinedAggregates.TabIndex = 24;
            this.chkUserDefinedAggregates.Tag = "Aggregate";
            this.chkUserDefinedAggregates.Text = "User Defined Aggregates";
            this.chkUserDefinedAggregates.UseVisualStyleBackColor = true;
            // 
            // chkUserDefinedTypes
            // 
            this.chkUserDefinedTypes.AutoSize = true;
            this.chkUserDefinedTypes.Checked = true;
            this.chkUserDefinedTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserDefinedTypes.Location = new System.Drawing.Point(3, 555);
            this.chkUserDefinedTypes.Name = "chkUserDefinedTypes";
            this.chkUserDefinedTypes.Size = new System.Drawing.Size(120, 17);
            this.chkUserDefinedTypes.TabIndex = 25;
            this.chkUserDefinedTypes.Tag = "UserDefinedType";
            this.chkUserDefinedTypes.Text = "User Defined Types";
            this.chkUserDefinedTypes.UseVisualStyleBackColor = true;
            // 
            // chkUserDefinedFunctions
            // 
            this.chkUserDefinedFunctions.AutoSize = true;
            this.chkUserDefinedFunctions.Checked = true;
            this.chkUserDefinedFunctions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserDefinedFunctions.Location = new System.Drawing.Point(3, 578);
            this.chkUserDefinedFunctions.Name = "chkUserDefinedFunctions";
            this.chkUserDefinedFunctions.Size = new System.Drawing.Size(194, 17);
            this.chkUserDefinedFunctions.TabIndex = 26;
            this.chkUserDefinedFunctions.Tag = "SQLUserDefinedFunction";
            this.chkUserDefinedFunctions.Text = "SQL User Defined Scalar Functions";
            this.chkUserDefinedFunctions.UseVisualStyleBackColor = true;
            // 
            // chkUserDefinedDataTypes
            // 
            this.chkUserDefinedDataTypes.AutoSize = true;
            this.chkUserDefinedDataTypes.Checked = true;
            this.chkUserDefinedDataTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserDefinedDataTypes.Location = new System.Drawing.Point(3, 601);
            this.chkUserDefinedDataTypes.Name = "chkUserDefinedDataTypes";
            this.chkUserDefinedDataTypes.Size = new System.Drawing.Size(146, 17);
            this.chkUserDefinedDataTypes.TabIndex = 27;
            this.chkUserDefinedDataTypes.Tag = "UserDefinedDataType";
            this.chkUserDefinedDataTypes.Text = "User Defined Data Types";
            this.chkUserDefinedDataTypes.UseVisualStyleBackColor = true;
            // 
            // chkXmlSchemaCollections
            // 
            this.chkXmlSchemaCollections.AutoSize = true;
            this.chkXmlSchemaCollections.Checked = true;
            this.chkXmlSchemaCollections.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXmlSchemaCollections.Location = new System.Drawing.Point(3, 624);
            this.chkXmlSchemaCollections.Name = "chkXmlSchemaCollections";
            this.chkXmlSchemaCollections.Size = new System.Drawing.Size(139, 17);
            this.chkXmlSchemaCollections.TabIndex = 28;
            this.chkXmlSchemaCollections.Tag = "XmlSchemaCollection";
            this.chkXmlSchemaCollections.Text = "Xml Schema Collections";
            this.chkXmlSchemaCollections.UseVisualStyleBackColor = true;
            // 
            // chkIndexes
            // 
            this.chkIndexes.AutoSize = true;
            this.chkIndexes.Checked = true;
            this.chkIndexes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIndexes.Location = new System.Drawing.Point(3, 647);
            this.chkIndexes.Name = "chkIndexes";
            this.chkIndexes.Size = new System.Drawing.Size(63, 17);
            this.chkIndexes.TabIndex = 29;
            this.chkIndexes.Tag = "Index";
            this.chkIndexes.Text = "Indexes";
            this.chkIndexes.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(3, 670);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 17);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Tag = "UserDefinedTableType";
            this.checkBox1.Text = "User Defined Table Types";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(3, 693);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(191, 17);
            this.checkBox2.TabIndex = 31;
            this.checkBox2.Tag = "SQLUserDefinedTableFunction";
            this.checkBox2.Text = "SQL User Defined Table Functions";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(3, 716);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(191, 17);
            this.checkBox3.TabIndex = 32;
            this.checkBox3.Tag = "CLRUserDefinedTableFunction";
            this.checkBox3.Text = "CLR User Defined Table Functions";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(3, 739);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(194, 17);
            this.checkBox4.TabIndex = 33;
            this.checkBox4.Tag = "CLRUserDefinedFunction";
            this.checkBox4.Text = "CLR User Defined Scalar Functions";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // chkCLRTriggers
            // 
            this.chkCLRTriggers.AutoSize = true;
            this.chkCLRTriggers.Checked = true;
            this.chkCLRTriggers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCLRTriggers.Location = new System.Drawing.Point(3, 762);
            this.chkCLRTriggers.Name = "chkCLRTriggers";
            this.chkCLRTriggers.Size = new System.Drawing.Size(113, 17);
            this.chkCLRTriggers.TabIndex = 34;
            this.chkCLRTriggers.Tag = "CLRDDLTrigger";
            this.chkCLRTriggers.Text = "CLR DDL Triggers";
            this.chkCLRTriggers.UseVisualStyleBackColor = true;
            // 
            // chkDMLTriggers
            // 
            this.chkDMLTriggers.AutoSize = true;
            this.chkDMLTriggers.Checked = true;
            this.chkDMLTriggers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDMLTriggers.Location = new System.Drawing.Point(3, 808);
            this.chkDMLTriggers.Name = "chkDMLTriggers";
            this.chkDMLTriggers.Size = new System.Drawing.Size(114, 17);
            this.chkDMLTriggers.TabIndex = 35;
            this.chkDMLTriggers.Tag = "SQLDMLTrigger";
            this.chkDMLTriggers.Text = "SQL DML Triggers";
            this.chkDMLTriggers.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(10, 12);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckStateChanged += new System.EventHandler(this.chkAll_CheckStateChanged);
            this.chkAll.Click += new System.EventHandler(this.chkAll_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lwDatabaseObjects);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lvDestination);
            this.splitContainer2.Panel2.Controls.Add(this.lvSource);
            this.splitContainer2.Panel2.Resize += new System.EventHandler(this.splitContainer2_Panel2_Resize);
            this.splitContainer2.Size = new System.Drawing.Size(721, 728);
            this.splitContainer2.SplitterDistance = 367;
            this.splitContainer2.TabIndex = 0;
            // 
            // lwDatabaseObjects
            // 
            this.lwDatabaseObjects.CheckBoxes = true;
            this.lwDatabaseObjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmType,
            this.clmSchema,
            this.clmName});
            this.lwDatabaseObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwDatabaseObjects.FullRowSelect = true;
            this.lwDatabaseObjects.Location = new System.Drawing.Point(0, 0);
            this.lwDatabaseObjects.Name = "lwDatabaseObjects";
            this.lwDatabaseObjects.Size = new System.Drawing.Size(721, 367);
            this.lwDatabaseObjects.SmallImageList = this.ilIcons;
            this.lwDatabaseObjects.TabIndex = 5;
            this.lwDatabaseObjects.UseCompatibleStateImageBehavior = false;
            this.lwDatabaseObjects.View = System.Windows.Forms.View.Details;
            this.lwDatabaseObjects.SelectedIndexChanged += new System.EventHandler(this.lwDatabaseObjects_SelectedIndexChanged);
            this.lwDatabaseObjects.Click += new System.EventHandler(this.lwDatabaseObjects_Click);
            // 
            // clmType
            // 
            this.clmType.Text = "Type";
            this.clmType.Width = 140;
            // 
            // clmSchema
            // 
            this.clmSchema.Text = "Schema";
            // 
            // clmName
            // 
            this.clmName.Text = "Name";
            this.clmName.Width = 517;
            // 
            // ilIcons
            // 
            this.ilIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcons.ImageStream")));
            this.ilIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilIcons.Images.SetKeyName(0, "Microsoft.SqlServer.Management.SqlManagerUI.Images.storedproc.ico");
            this.ilIcons.Images.SetKeyName(1, "Microsoft.SqlServer.Management.SqlManagerUI.Images.table.ico");
            this.ilIcons.Images.SetKeyName(2, "Microsoft.SqlServer.Management.SqlManagerUI.Images.udf.ico");
            this.ilIcons.Images.SetKeyName(3, "Microsoft.SqlServer.Management.SqlManagerUI.Images.view.ico");
            this.ilIcons.Images.SetKeyName(4, "Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer.application_role.i" +
                    "co");
            this.ilIcons.Images.SetKeyName(5, "Microsoft.SqlServer.Management.SqlMgmt.Images.database_roles_16x.ico");
            this.ilIcons.Images.SetKeyName(6, "Microsoft.SqlServer.Management.SqlManagerUI.Images.default.ico");
            this.ilIcons.Images.SetKeyName(7, "Microsoft.SqlServer.Management.SqlMgmt.Images.full_text_catalog.ico");
            this.ilIcons.Images.SetKeyName(8, "Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer.message_type.ico");
            this.ilIcons.Images.SetKeyName(9, "Microsoft.SqlServer.Management.SqlManagerUI.Images.partition_function.ico");
            this.ilIcons.Images.SetKeyName(10, "Microsoft.SqlServer.Management.SqlManagerUI.Images.partition_scheme.ico");
            this.ilIcons.Images.SetKeyName(11, "Microsoft.VisualStudio.DataTools.Default.ico");
            this.ilIcons.Images.SetKeyName(12, "Microsoft.SqlServer.Management.SqlManagerUI.Images.plan_guide_enabled.ico");
            this.ilIcons.Images.SetKeyName(13, "Microsoft.SqlServer.Management.SqlManagerUI.Images.rule.ico");
            this.ilIcons.Images.SetKeyName(14, "Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer.schema.ico");
            this.ilIcons.Images.SetKeyName(15, "Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer.remote_service.ico" +
                    "");
            this.ilIcons.Images.SetKeyName(16, "Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer.contract.ico");
            this.ilIcons.Images.SetKeyName(17, "Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer.queue.ico");
            this.ilIcons.Images.SetKeyName(18, "Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer.route.ico");
            this.ilIcons.Images.SetKeyName(19, "Microsoft.VisualStudio.DataTools.Assembly.ico");
            this.ilIcons.Images.SetKeyName(20, "Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer.database_trigger.i" +
                    "co");
            this.ilIcons.Images.SetKeyName(21, "Microsoft.SqlServer.Management.SqlManagerUI.Images.synonym.ico");
            this.ilIcons.Images.SetKeyName(22, "Microsoft.SqlServer.Management.SqlMgmt.Images.user_16x.ico");
            this.ilIcons.Images.SetKeyName(23, "Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer.aggregate_valued_f" +
                    "unction.ico");
            this.ilIcons.Images.SetKeyName(24, "Microsoft.SqlServer.Management.SqlMgmt.Images.user_defined_data_type.ico");
            this.ilIcons.Images.SetKeyName(25, "Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer.user_defined_objec" +
                    "t_type.ico");
            this.ilIcons.Images.SetKeyName(26, "Microsoft.SqlServer.Management.SqlManagerUI.Images.XML_schemas_16x.ico");
            this.ilIcons.Images.SetKeyName(27, "Microsoft.VisualStudio.DataTools.Trigger.ico");
            this.ilIcons.Images.SetKeyName(28, "Microsoft.VisualStudio.DataTools.Index.ico");
            this.ilIcons.Images.SetKeyName(29, "Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer.broker_service.ico" +
                    "");
            this.ilIcons.Images.SetKeyName(30, "Microsoft.SqlServer.Management.SqlManagerUI.Images.table_valued_function.ico");
            this.ilIcons.Images.SetKeyName(31, "Microsoft.SqlServer.Management.SqlManagerUI.Images.scalar_valued_function.ico");
            // 
            // lvDestination
            // 
            this.lvDestination.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvDestination.FullRowSelect = true;
            this.lvDestination.HideSelection = false;
            this.lvDestination.Location = new System.Drawing.Point(305, 69);
            this.lvDestination.MultiSelect = false;
            this.lvDestination.Name = "lvDestination";
            this.lvDestination.Size = new System.Drawing.Size(123, 110);
            this.lvDestination.TabIndex = 4;
            this.lvDestination.UseCompatibleStateImageBehavior = false;
            this.lvDestination.View = System.Windows.Forms.View.Details;
            this.lvDestination.SelectedIndexChanged += new System.EventHandler(this.lvDestination_SelectedIndexChanged);
            this.lvDestination.Resize += new System.EventHandler(this.lvDestination_Resize);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Line";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Text (Destination)";
            this.columnHeader4.Width = 198;
            // 
            // lvSource
            // 
            this.lvSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvSource.FullRowSelect = true;
            this.lvSource.HideSelection = false;
            this.lvSource.Location = new System.Drawing.Point(157, 71);
            this.lvSource.MultiSelect = false;
            this.lvSource.Name = "lvSource";
            this.lvSource.Size = new System.Drawing.Size(114, 102);
            this.lvSource.TabIndex = 3;
            this.lvSource.UseCompatibleStateImageBehavior = false;
            this.lvSource.View = System.Windows.Forms.View.Details;
            this.lvSource.SelectedIndexChanged += new System.EventHandler(this.lvSource_SelectedIndexChanged);
            this.lvSource.Resize += new System.EventHandler(this.lvSource_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Line";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Text (Source)";
            this.columnHeader2.Width = 147;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(987, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFromDB1ToDB2,
            this.btnFromDB2ToDB1});
            this.toolStripSplitButton1.Image = global::DBCompare.Properties.Resources.script_gear_icon;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // btnFromDB1ToDB2
            // 
            this.btnFromDB1ToDB2.Name = "btnFromDB1ToDB2";
            this.btnFromDB1ToDB2.Size = new System.Drawing.Size(135, 22);
            this.btnFromDB1ToDB2.Text = "DB1 -> DB2";
            this.btnFromDB1ToDB2.Click += new System.EventHandler(this.btnFromDB1ToDB2_Click);
            // 
            // btnFromDB2ToDB1
            // 
            this.btnFromDB2ToDB1.Name = "btnFromDB2ToDB1";
            this.btnFromDB2ToDB1.Size = new System.Drawing.Size(135, 22);
            this.btnFromDB2ToDB1.Text = "DB1 <- DB2";
            this.btnFromDB2ToDB1.Click += new System.EventHandler(this.btnFromDB2ToDB1_Click);
            // 
            // chkCLRDMLTriggers
            // 
            this.chkCLRDMLTriggers.AutoSize = true;
            this.chkCLRDMLTriggers.Checked = true;
            this.chkCLRDMLTriggers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCLRDMLTriggers.Location = new System.Drawing.Point(3, 785);
            this.chkCLRDMLTriggers.Name = "chkCLRDMLTriggers";
            this.chkCLRDMLTriggers.Size = new System.Drawing.Size(114, 17);
            this.chkCLRDMLTriggers.TabIndex = 36;
            this.chkCLRDMLTriggers.Tag = "CLRDMLTrigger";
            this.chkCLRDMLTriggers.Text = "CLR DML Triggers";
            this.chkCLRDMLTriggers.UseVisualStyleBackColor = true;
            // 
            // ObjectCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 757);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ObjectCompare";
            this.Text = "ObjectCompare";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ObjectCompare_Load);
            this.Shown += new System.EventHandler(this.ObjectCompare_Shown);
            this.Resize += new System.EventHandler(this.ObjectCompare_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chkFullTextCatalogs;
        private System.Windows.Forms.CheckBox chkDefaults;
        private System.Windows.Forms.CheckBox chkDatabaseRoles;
        private System.Windows.Forms.CheckBox chkApplicationRoles;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkFullTextStopLists;
        private System.Windows.Forms.CheckBox chkUserDefinedTableTypes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkPartitionFunctions;
        private System.Windows.Forms.CheckBox chkMessageTypes;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView lwDatabaseObjects;
        private System.Windows.Forms.ColumnHeader clmType;
        private System.Windows.Forms.ColumnHeader clmSchema;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.CheckBox chkPartitionSchemes;
        private System.Windows.Forms.CheckBox chkPlanGuides;
        private System.Windows.Forms.CheckBox chkRemoteServiceBindings;
        private System.Windows.Forms.CheckBox chkRules;
        private System.Windows.Forms.CheckBox chkSchemas;
        private System.Windows.Forms.CheckBox chkServiceContracts;
        private System.Windows.Forms.CheckBox chkQueues;
        private System.Windows.Forms.CheckBox chkRoutes;
        private System.Windows.Forms.CheckBox chkAssemblies;
        private System.Windows.Forms.CheckBox chkStoredProcedures;
        private System.Windows.Forms.CheckBox chkTriggers;
        private System.Windows.Forms.CheckBox chkViews;
        private System.Windows.Forms.CheckBox chkSynonyms;
        private System.Windows.Forms.CheckBox chkTables;
        private System.Windows.Forms.CheckBox chkUsers;
        private System.Windows.Forms.CheckBox chkUserDefinedAggregates;
        private System.Windows.Forms.CheckBox chkUserDefinedTypes;
        private System.Windows.Forms.CheckBox chkUserDefinedFunctions;
        private System.Windows.Forms.CheckBox chkUserDefinedDataTypes;
        private System.Windows.Forms.CheckBox chkXmlSchemaCollections;
        private System.Windows.Forms.ImageList ilIcons;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem btnFromDB1ToDB2;
        private System.Windows.Forms.ToolStripMenuItem btnFromDB2ToDB1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView lvDestination;
        private System.Windows.Forms.ListView lvSource;
        private System.Windows.Forms.CheckBox chkIndexes;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox chkCLRTriggers;
        private System.Windows.Forms.CheckBox chkDMLTriggers;
        private System.Windows.Forms.CheckBox chkCLRDMLTriggers;
    }
}

// This file has been generated by the GUI designer. Do not modify.
namespace GraphTool
{
	public partial class GraphWindow
	{
		private global::Gtk.HBox hbox2;
		private global::Gtk.VBox vbox4;
		private global::Florence.GtkSharp.PlotWidget timeSeriresPlot;
		private global::Gtk.VBox vbox3;
		private global::Gtk.CheckButton comparisonModeCheckBox;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TextView timeSeriesTextView;
		private global::Gtk.Label infoLabel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget GraphTool.GraphWindow
			this.Name = "GraphTool.GraphWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("GraphWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child GraphTool.GraphWindow.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
//			this.timeSeriresPlot = new global::Florence.GtkSharp.PlotWidget ();
//			this.timeSeriresPlot.WidthRequest = 678;
//			this.timeSeriresPlot.HeightRequest = 405;
//			this.timeSeriresPlot.Name = "timeSeriresPlot";
			this.vbox4.Add (this.timeSeriresPlot);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.timeSeriresPlot]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			this.hbox2.Add (this.vbox4);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.vbox4]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			w2.Padding = ((uint)(4));
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.comparisonModeCheckBox = new global::Gtk.CheckButton ();
			this.comparisonModeCheckBox.CanFocus = true;
			this.comparisonModeCheckBox.Name = "comparisonModeCheckBox";
			this.comparisonModeCheckBox.Label = global::Mono.Unix.Catalog.GetString ("Comparison Mode");
			this.comparisonModeCheckBox.DrawIndicator = true;
			this.comparisonModeCheckBox.UseUnderline = true;
			this.vbox3.Add (this.comparisonModeCheckBox);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.comparisonModeCheckBox]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.HscrollbarPolicy = ((global::Gtk.PolicyType)(2));
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.timeSeriesTextView = new global::Gtk.TextView ();
			this.timeSeriesTextView.CanFocus = true;
			this.timeSeriesTextView.Name = "timeSeriesTextView";
			this.timeSeriesTextView.Editable = false;
			this.timeSeriesTextView.CursorVisible = false;
			this.GtkScrolledWindow.Add (this.timeSeriesTextView);
			this.vbox3.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.GtkScrolledWindow]));
			w5.Position = 1;
			// Container child vbox3.Gtk.Box+BoxChild
			this.infoLabel = new global::Gtk.Label ();
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Info Label");
			this.vbox3.Add (this.infoLabel);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.infoLabel]));
			w6.Position = 2;
			w6.Expand = false;
			w6.Fill = false;
			this.hbox2.Add (this.vbox3);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.vbox3]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.Add (this.hbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 831;
			this.DefaultHeight = 556;
			this.Show ();
		}
	}
}

using System;
using Xamarin.Forms;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace ColorXamarim
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            StackLayout layout = new StackLayout();
            layout.Spacing = 10;

            ScrollView view = new ScrollView();
            layout.Orientation = StackOrientation.Vertical;
            Type tipo = typeof(Color);
            Color c = Color.AliceBlue;



            foreach (var field in tipo.GetRuntimeFields().Where(fi => fi.IsPublic && fi.IsStatic && fi.GetValue(null) is Color))
            {
                StackLayout line = new StackLayout();
                line.Orientation = StackOrientation.Horizontal;

                Frame frame = new Frame();
                frame.Padding = 10;
                 
                BoxView box = new BoxView();

                Label l = new Label();
                l.Text = field.Name;
                box.Color = (Color)field.GetValue(null); ;

                line.Children.Add(box);
                line.Children.Add(l);
                frame.Content = line;
                layout.Children.Add(frame);

            } 
            view.Content = layout;
            ScrollView scroll = new ScrollView();
            scroll.Content = view;

            this.Content = scroll;
        }
    }
}

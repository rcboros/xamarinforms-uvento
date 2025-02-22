﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UventoXF.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UventoXF.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarCarouselView : ContentView
    {
        public ObservableCollection<DateItem> ItemsSource { get; set; }

        public static readonly BindableProperty ItemsSourceProperty =
           BindableProperty
           .Create(
               propertyName: "ItemsSource",
               returnType: typeof(ObservableCollection<DateItem>),
               declaringType: typeof(CalendarCarouselView),
               defaultValue: null,
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: ItemsSourcePropertyChanged);

        public CalendarCarouselView()
        {
            InitializeComponent();
        }

        private static async void ItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var items = newValue as ObservableCollection<DateItem>;
            var control = (CalendarCarouselView)bindable;

            control.listDates.ItemsSource = items;
            var index = items.ToList().FindIndex(p => p.selected);
            if (index < items.Count)
                index += 2;

            await Task.Delay(250);

            control.listDates.ScrollTo(index);
        }
    }
}
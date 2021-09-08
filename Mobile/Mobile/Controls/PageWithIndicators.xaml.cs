using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageWithIndicators : ContentView
    {
        public static BindableProperty ChildContentProperty = BindableProperty.Create(
            propertyName: nameof(ChildContent),
            returnType: typeof(View),
            declaringType: typeof(ContentView),
            defaultValue: new ContentView(),
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HandleChildContentChanged
        );

        public static BindableProperty IsBusyProperty = BindableProperty.Create(
            propertyName: nameof(IsBusy),
            returnType: typeof(bool),
            declaringType: typeof(ContentView),
            defaultValue: false,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HandleIsBusyPropertyChanged
        );

        public static BindableProperty IsLoadingProperty = BindableProperty.Create(
            propertyName: nameof(IsLoading),
            returnType: typeof(bool),
            declaringType: typeof(ContentView),
            defaultValue: false,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HandleIsLoadingPropertyChanged
        );

        public PageWithIndicators()
        {
            InitializeComponent();
        }

        public ContentView ContentContainer => _contentContainer;
        public StackLayout IsBusyContainer => _isBusyContainer;
        public StackLayout IsLoadingContainer => _isLoadingContainer;
        public ActivityIndicator IsBusyIndicator => _isBusyIndicator;
        public ActivityIndicator IsLoadingIndicator => _isLoadingIndicator;

        public View ChildContent
        {
            get => (View)GetValue(ChildContentProperty);
            set
            {
                if (ChildContent.Equals(value))
                    return;
                SetValue(ChildContentProperty, value);
            }
        }

        public bool IsBusy
        {
            get => (bool)GetValue(IsBusyProperty);
            set
            {
                if (IsBusy == value)
                    return;
                SetValue(IsBusyProperty, value);
            }
        }

        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set
            {
                if (IsLoading == value)
                    return;
                SetValue(IsLoadingProperty, value);
            }
        }

        private static void HandleChildContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable == null)
                return;

            var targetView = (PageWithIndicators)bindable;
            targetView.ContentContainer.Content = (View)newValue;
        }

        private static void HandleIsBusyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable == null)
                return;
            var targetView = (PageWithIndicators)bindable;
            bool isBusy = (bool)newValue;
            targetView.IsBusyContainer.IsVisible = isBusy;
            targetView.IsBusyIndicator.IsRunning = isBusy;
        }

        private static void HandleIsLoadingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable == null)
                return;
            var targetView = (PageWithIndicators)bindable;
            bool isLoading = (bool)newValue;
            targetView.IsLoadingContainer.IsVisible = isLoading;
            targetView.IsLoadingIndicator.IsRunning = isLoading;
        }
    }
}
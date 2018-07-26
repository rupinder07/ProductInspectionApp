using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace ProductInspection.Behaviors
{
    public class EmailBehavior : Behavior<Entry>
    {

        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        private bool _isValid = false;

        public bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnTextChanged;
        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            bool isValid = IsValidEmail(e.NewTextValue);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }

        public static bool IsValidEmail(string email)
        {
            return (Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
        }
    }
}

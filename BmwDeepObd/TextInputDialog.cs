﻿using System;
using Android.Content;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace BmwDeepObd
{
    public class TextInputDialog : AlertDialog.Builder
    {
        private Android.App.Activity _activity;
        private AlertDialog _dialog;
        private View _view;
        private TextView _textViewMessage;
        private EditText _editTextText;

        public string Message
        {
            get
            {
                if (_textViewMessage != null)
                {
                    return _textViewMessage.Text;
                }
                return string.Empty;
            }
            set
            {
                if (_textViewMessage != null)
                {
                    _textViewMessage.Text = value;
                }
            }
        }

        public string Text
        {
            get
            {
                if (_editTextText != null)
                {
                    return _editTextText.Text;
                }
                return string.Empty;
            }
            set
            {
                if (_editTextText != null)
                {
                    _editTextText.Text = value;
                }
            }
        }

        public TextInputDialog(Context context) : base(context)
        {
            LoadView(context);
        }

        public TextInputDialog(Context context, int themeResId) : base(context, themeResId)
        {
            LoadView(context);
        }

        protected void LoadView(Context context)
        {
            SetCancelable(false);
            _activity = context as Android.App.Activity;
            if (_activity != null)
            {
                _view = _activity.LayoutInflater.Inflate(Resource.Layout.text_input, null);
                SetView(_view);

                _textViewMessage = _view.FindViewById<TextView>(Resource.Id.textViewMessage);
                _editTextText = _view.FindViewById<EditText>(Resource.Id.editTextText);
            }
        }

        public new void Show()
        {
            if (_dialog == null)
            {
                _dialog = base.Show();
            }
        }

        public new void SetMessage(string message)
        {
            Message = message;
        }

        public new void SetMessage(int messageId)
        {
            if (_activity != null)
            {
                Message = _activity.GetString(messageId);
            }
        }

        public void Dismiss()
        {
            _dialog?.Dismiss();
            _dialog = null;
        }
    }
}
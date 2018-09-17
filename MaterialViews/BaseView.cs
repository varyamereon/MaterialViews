using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Widget;

namespace MaterialViews
{
    public abstract class BaseView : FrameLayout
    {
        private const int TYPEFACE_SANS = 1;
        private const int TYPEFACE_SERIF = 2;
        private const int TYPEFACE_MONOSPACE = 3;

        protected TextView viewTitle;
        protected TextView viewSubtitle;
        protected ImageView viewIcon;
        protected AvatarImageView viewAvatar;
        protected AppCompatCheckBox viewCheckBox;

        public BaseView(Context context) : base(context) => Init(context, null, 0, 0);

        public BaseView(Context context, IAttributeSet attrs) : base(context, attrs) => Init(context, attrs, 0, 0);

        public BaseView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr) => Init(context, attrs, defStyleAttr, 0);

        public BaseView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes) => Init(context, attrs, defStyleAttr, defStyleRes);

        private void Init(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
        {
            Inflate(context, GetLayoutResourceId(), this);

            viewTitle = FindViewById<TextView>(Resource.Id.listItemTitle);
            viewSubtitle = FindViewById<TextView>(Resource.Id.listItemSubtitle);
            viewIcon = FindViewById<ImageView>(Resource.Id.listItemIcon);
            viewAvatar = FindViewById<AvatarImageView>(Resource.Id.listItemAvatar);
            viewCheckBox = FindViewById<AppCompatCheckBox>(Resource.Id.listItemCheckbox);

            TypedArray ta = context.ObtainStyledAttributes(attrs, GetStyleAttributeIds(), defStyleAttr, defStyleRes);
            UseStyleAttributes(ta);

            viewTitle.SetSingleLine(true);
            PrepareChildViews();
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            SetMeasuredDimension(MeasureSpec.GetSize(widthMeasureSpec), (int)Math.Round(GetMinimumHeightInList() * Resources.Configuration.FontScale));
        }
        
        /// <summary>
        /// Returns the height of the view if using WRAP_CONTENT in layout_height.
        /// </summary>
        /// <returns>The height of the view if using WRAP_CONTENT in layout_height.</returns>
        protected abstract int GetMinimumHeightInList();

        /// <summary>
        /// This will get called after child views are found in case subclass wants to make any modifications.
        /// </summary>
        protected abstract void PrepareChildViews();

        /// <summary>
        /// Use the given styledAttributes to prepare view data.
        /// </summary>
        /// <param name="ta">Attrs that were generated using styleableResourceId.</param>
        protected abstract void UseStyleAttributes(TypedArray ta);

        /// <summary>
        /// Returns the desired attributes for this view.
        /// </summary>
        /// <returns>The desired attributes for this view.</returns>
        protected abstract int[] GetStyleAttributeIds();

        /// <summary>
        /// Returns the resource id to inflate.
        /// </summary>
        /// <returns>The resource id to inflate.</returns>
        protected abstract int GetLayoutResourceId();

        /// <summary>
        /// Prepares the <see cref="TextView"/> with custom attributes.
        /// </summary>
        /// <param name="view">The <see cref="TextView"/> to setup.</param>
        /// <param name="title">The text to display.</param>
        /// <param name="color">The color of the text.</param>
        /// <param name="size"></param>
        /// <param name="styleIndex"></param>
        /// <param name="typefaceIndex"></param>
        /// <param name="familyName"></param>
        protected void PrepareTextViewWithAttrValues(TextView view, string title, Color color, float size, int styleIndex, int typefaceIndex, string familyName)
        {
            if (title != null)
                view.Text = title;

            if (color != -1)
                view.SetTextColor(color);

            if (size != -1)
                view.SetTextSize(ComplexUnitType.Px, size);

            Typeface typeface = null;
            if (familyName != null)
            {
                typeface = Typeface.Create(familyName, (TypefaceStyle)Enum.ToObject(typeof(TypefaceStyle), typefaceIndex));
                if (typeface != null)
                {
                    view.Typeface = typeface;
                    return;
                }
            }
            switch (typefaceIndex)
            {
                case TYPEFACE_SANS:
                    typeface = Typeface.SansSerif;
                    break;

                case TYPEFACE_SERIF:
                    typeface = Typeface.Serif;
                    break;

                case TYPEFACE_MONOSPACE:
                    typeface = Typeface.Monospace;
                    break;
            }
            view.SetTypeface(typeface, (TypefaceStyle)Enum.ToObject(typeof(TypefaceStyle), typefaceIndex));
        }

        /// <summary>
        /// Prepares the icon with custom attributes.
        /// </summary>
        /// <param name="iconDrawable">The drawable to display.</param>
        /// <param name="iconTintColor">The color to tint the drawable with.</param>
        protected void PrepareIconViewWithAttrValues(Drawable iconDrawable, Color iconTintColor)
        {
            if (iconDrawable != null)
                viewIcon.SetImageDrawable(iconDrawable);

            if (iconTintColor != -1)
                viewIcon.SetColorFilter(iconTintColor);
        }

        /// <summary>
        /// Prepares the avatar with custom attributes.
        /// </summary>
        /// <param name="avatarDrawable">The drawable to display.</param>
        protected void PrepareAvatarViewWithAttrValues(Drawable avatarDrawable)
        {
            if (avatarDrawable != null)
                viewAvatar.SetImageDrawable(avatarDrawable);
        }

        /// <summary>
        /// Returns the title <see cref="TextView"/>.
        /// </summary>
        /// <returns>The title <see cref="TextView"/>.</returns>
        protected TextView GetTitleView() => viewTitle;

        /// <summary>
        /// Returns the subtitle <see cref="TextView"/>.
        /// </summary>
        /// <returns>The subtitle <see cref="TextView"/>.</returns>
        protected TextView GetSubtitleView() => viewSubtitle;

        /// <summary>
        /// Returns the <see cref="ImageView"/> with the id listItemIcon.
        /// </summary>
        /// <returns>The <see cref="ImageView"/> with the id listItemIcon.</returns>
        protected ImageView GetIconImageView() => viewIcon;

        /// <summary>
        /// Returns the <see cref="ImageView"/> with the id listItemAvatar.
        /// </summary>
        /// <returns>The <see cref="ImageView"/> with the id listItemAvatar.</returns>
        protected AvatarImageView GetAvatarImageView() => viewAvatar;

        /// <summary>
        /// Returns the <see cref="AppCompatCheckBox"/> with the id listItemCheckBox.
        /// </summary>
        /// <returns>The <see cref="AppCompatCheckBox"/> with the id listItemCheckBox.</returns>
        protected AppCompatCheckBox GetCheckBoxView() => viewCheckBox;
    }
}
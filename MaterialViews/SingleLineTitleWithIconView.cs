using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MaterialViews
{
    /// <summary>
    /// List item consisting of a single line with an icon and a title.
    /// </summary>
    public class SingleLineTitleWithIconView : BaseView
    {
        public SingleLineTitleWithIconView(Context context) : base(context)
        {
        }

        public SingleLineTitleWithIconView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public SingleLineTitleWithIconView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public SingleLineTitleWithIconView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected override int GetLayoutResourceId() => Resource.Layout.single_line_title_with_icon_view;

        protected override int GetMinimumHeightInList() => Context.Resources.GetDimensionPixelSize(Resource.Dimension.singleLineListItemHeight);

        protected override int[] GetStyleAttributeIds() => Resource.Styleable.SingleLineIconWithTextView;

        protected override void UseStyleAttributes(TypedArray attrs)
        {
            var titleText = attrs.GetString(Resource.Styleable.SingleLineIconWithTextView_textForTitle);
            var titleTextColor = attrs.GetColor(Resource.Styleable.SingleLineIconWithTextView_textColorForTitle, -1);
            var titleTextSize = attrs.GetDimension(Resource.Styleable.SingleLineIconWithTextView_textSizeForTitle, -1);
            var titleTextStyle = attrs.GetInt(Resource.Styleable.SingleLineIconWithTextView_textStyleForTitle, (int)Enum.ToObject(typeof(TypefaceStyle), TypefaceStyle.Normal));
            var titleTypeface = attrs.GetInt(Resource.Styleable.SingleLineIconWithTextView_typefaceForTitle, 0);
            var titleFontFamily = attrs.GetString(Resource.Styleable.SingleLineIconWithTextView_fontFamilyForTitle);
            var iconSrc = attrs.GetDrawable(Resource.Styleable.SingleLineIconWithTextView_iconSrc);
            var iconTint = attrs.GetColor(Resource.Styleable.SingleLineIconWithTextView_iconTint, -1);
            attrs.Recycle();

            PrepareTextViewWithAttrValues(viewTitle, titleText, titleTextColor, titleTextSize, titleTextStyle, titleTypeface, titleFontFamily);
            PrepareIconViewWithAttrValues(iconSrc, iconTint);
        }

        protected override void PrepareChildViews() { }

        public TextView TitleView => GetTitleView();

        public ImageView IconImageView => GetIconImageView();
    }
}
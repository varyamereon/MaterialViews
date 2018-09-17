using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Widget;

namespace MaterialViews
{
    /// <summary>
    /// List item consisting of two lines with an icon, a title, and a subtitle.
    /// </summary>
    public class TwoLineIconWithTextView : BaseView
    {
        public TwoLineIconWithTextView(Context context) : base(context)
        {
        }

        public TwoLineIconWithTextView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public TwoLineIconWithTextView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public TwoLineIconWithTextView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected override int GetLayoutResourceId() => Resource.Layout.two_line_icon_with_text_view;

        protected override int GetMinimumHeightInList() => Context.Resources.GetDimensionPixelSize(Resource.Dimension.twoLineListItemHeight);

        protected override int[] GetStyleAttributeIds() => Resource.Styleable.TwoLineIconWithTextView;

        protected override void UseStyleAttributes(TypedArray attrs)
        {
            var titleText = attrs.GetString(Resource.Styleable.TwoLineIconWithTextView_textForTitle);
            Color titleTextColor = attrs.GetColor(Resource.Styleable.TwoLineIconWithTextView_textColorForTitle, -1);
            var titleTextSize = attrs.GetDimension(Resource.Styleable.TwoLineIconWithTextView_textSizeForTitle, -1);
            var titleTextStyle = attrs.GetInt(Resource.Styleable.TwoLineIconWithTextView_textStyleForTitle, (int)Enum.ToObject(typeof(TypefaceStyle), TypefaceStyle.Normal));
            var titleTypeface = attrs.GetInt(Resource.Styleable.TwoLineIconWithTextView_typefaceForTitle,0);
            var titleFontFamily = attrs.GetString(Resource.Styleable.TwoLineIconWithTextView_fontFamilyForTitle);
            var subtitleText = attrs.GetString(Resource.Styleable.TwoLineIconWithTextView_textForSubtitle);
            Color subtitleTextColor = attrs.GetColor(Resource.Styleable.TwoLineIconWithTextView_textColorForSubtitle, -1);
            var subtitleTextSize = attrs.GetDimension(Resource.Styleable.TwoLineIconWithTextView_textSizeForSubtitle,-1);
            var subtitleTextStyle = attrs.GetInt(Resource.Styleable.TwoLineIconWithTextView_textStyleForSubtitle, (int)Enum.ToObject(typeof(TypefaceStyle), TypefaceStyle.Normal));
            var subtitleTypeface = attrs.GetInt(Resource.Styleable.TwoLineIconWithTextView_typefaceForSubtitle,0);
            var subtitleFontFamily = attrs.GetString(Resource.Styleable.TwoLineIconWithTextView_fontFamilyForSubtitle);
            Drawable iconSrc = attrs.GetDrawable(Resource.Styleable.TwoLineIconWithTextView_iconSrc);
            Color iconTint = attrs.GetColor(Resource.Styleable.TwoLineIconWithTextView_iconTint,-1);
            attrs.Recycle();

            PrepareTextViewWithAttrValues(viewTitle, titleText, titleTextColor, titleTextSize, titleTextStyle, titleTypeface, titleFontFamily);
            PrepareTextViewWithAttrValues(viewSubtitle, subtitleText, subtitleTextColor, subtitleTextSize, subtitleTextStyle, subtitleTypeface, subtitleFontFamily);
            PrepareIconViewWithAttrValues(iconSrc, iconTint);
        }

        protected override void PrepareChildViews() => viewSubtitle.SetMaxLines(1);

        public TextView TitleView => GetTitleView();

        public TextView SubtitleView => GetSubtitleView();

        public ImageView IconImageView => GetIconImageView();
    }
}
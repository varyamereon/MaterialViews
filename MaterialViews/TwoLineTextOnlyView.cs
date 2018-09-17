using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Widget;
using System;

namespace MaterialViews
{
    /// <summary>
    /// List item consisting of two lines with a title and a subtitle.
    /// </summary>
    public class TwoLineTextOnlyView : BaseView
    {
        public TwoLineTextOnlyView(Context context) : base(context)
        {
        }

        public TwoLineTextOnlyView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public TwoLineTextOnlyView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public TwoLineTextOnlyView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected override int GetLayoutResourceId() => Resource.Layout.two_line_text_only_view;

        protected override int GetMinimumHeightInList() => Context.Resources.GetDimensionPixelSize(Resource.Dimension.twoLineListItemHeight);

        protected override int[] GetStyleAttributeIds() => Resource.Styleable.TwoLineTextOnlyView;

        protected override void PrepareChildViews() => viewSubtitle.SetMaxLines(1);

        protected override void UseStyleAttributes(TypedArray attrs)
        {
            var titleText = attrs.GetString(Resource.Styleable.TwoLineTextOnlyView_textForTitle);
            Color titleTextColor = attrs.GetColor(Resource.Styleable.TwoLineTextOnlyView_textColorForTitle, -1);
            var titleTextSize = attrs.GetDimension(Resource.Styleable.TwoLineTextOnlyView_textSizeForTitle, -1);
            var titleTextStyle = attrs.GetInt(Resource.Styleable.TwoLineTextOnlyView_textStyleForTitle, (int)Enum.ToObject(typeof(TypefaceStyle), TypefaceStyle.Normal));
            var titleTypeface = attrs.GetInt(Resource.Styleable.TwoLineTextOnlyView_typefaceForTitle, 0);
            var titleFontFamily = attrs.GetString(Resource.Styleable.TwoLineTextOnlyView_fontFamilyForTitle);
            var subtitleText = attrs.GetString(Resource.Styleable.TwoLineTextOnlyView_textForSubtitle);
            Color subtitleTextColor = attrs.GetColor(Resource.Styleable.TwoLineTextOnlyView_textColorForSubtitle, -1);
            var subtitleTextSize = attrs.GetDimension(Resource.Styleable.TwoLineTextOnlyView_textSizeForSubtitle, -1);
            var subtitleTextStyle = attrs.GetInt(Resource.Styleable.TwoLineTextOnlyView_textStyleForSubtitle, (int)Enum.ToObject(typeof(TypefaceStyle), TypefaceStyle.Normal));
            var subtitleTypeface = attrs.GetInt(Resource.Styleable.TwoLineTextOnlyView_typefaceForSubtitle, 0);
            var subtitleFontFamily = attrs.GetString(Resource.Styleable.TwoLineTextOnlyView_fontFamilyForSubtitle);
            attrs.Recycle();

            PrepareTextViewWithAttrValues(TitleView, titleText, titleTextColor, titleTextSize, titleTextStyle, titleTypeface, titleFontFamily);
            PrepareTextViewWithAttrValues(SubtitleView, subtitleText, subtitleTextColor, subtitleTextSize, subtitleTextStyle, subtitleTypeface, subtitleFontFamily);
        }

        public TextView TitleView => GetTitleView();

        public TextView SubtitleView => GetSubtitleView();
    }
}

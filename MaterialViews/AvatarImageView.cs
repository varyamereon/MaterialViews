using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Graphics.Drawable;
using Android.Util;
using Android.Widget;

namespace MaterialViews
{
    /// <summary>
    /// Variant of <see cref="ImageView"/> that masks the image in an oval.
    /// </summary>
    public class AvatarImageView : ImageView
    {
        public AvatarImageView(Context context) : base(context)
        {
        }

        public AvatarImageView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public AvatarImageView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public AvatarImageView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        public override void SetImageResource(int resId) => SetImageBitmap(BitmapFactory.DecodeResource(Resources, resId));

        public override void SetImageDrawable(Drawable drawable)
        {
            Bitmap bitmap = null;

            if (drawable is BitmapDrawable bitmapDrawable)
            {
                if (bitmapDrawable.Bitmap != null)
                    bitmap = bitmapDrawable.Bitmap;
            }
            else
            {
                if (drawable.IntrinsicWidth <= 0 || drawable.IntrinsicHeight <= 0)
                {
                    bitmap = Bitmap.CreateBitmap(1, 1, Bitmap.Config.Argb8888);
                }
                else
                {
                    bitmap = Bitmap.CreateBitmap(drawable.IntrinsicWidth, drawable.IntrinsicHeight, Bitmap.Config.Argb8888);
                }

                var canvas = new Canvas(bitmap);
                drawable.SetBounds(0, 0, canvas.Width, canvas.Height);
                drawable.Draw(canvas);
            }

            SetImageBitmap(bitmap);
        }

        public override void SetImageBitmap(Bitmap bm)
        {
            RoundedBitmapDrawable roundedDrawable = RoundedBitmapDrawableFactory.Create(Resources, bm);
            roundedDrawable.Circular = true;
            base.SetImageDrawable(roundedDrawable);
        }

        public override void SetImageIcon(Icon icon)
        {
            if (icon == null)
            {
                base.SetImageDrawable(null);
            }
            else
            {
                SetImageDrawable(icon.LoadDrawable(Context));
            }
        }
    }
}
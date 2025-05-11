using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2
{
    public partial class Rates : Form
    {
        private int rating = 0;
        private readonly int starCount = 5;
        private readonly Rectangle[] starRects;

        public Rates()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            starRects = new Rectangle[starCount];

            Button submitButton = new Button();
            submitButton.Text = "Submit";
            submitButton.Size = new Size(100, 40);
            submitButton.Location = new Point((this.ClientSize.Width - submitButton.Width) / 2, 200);
            submitButton.Click += SubmitButton_Click;
            this.Controls.Add(submitButton);

            this.Resize += (s, e) => this.Invalidate();
        }

        public int Ratings
        {
            get => rating;
            set
            {
                rating = Math.Max(0, Math.Min(starCount, value));
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.Clear(Color.Honeydew);

            int starsTop = 80;
            int starsWidth = Width - 80;
            int starSize = starsWidth / starCount - 10;

            for (int i = 0; i < starCount; i++)
            {
                int x = 40 + i * (starSize + 10);
                int y = starsTop;

                var rect = new Rectangle(x, y, starSize, starSize);
                starRects[i] = rect;

                DrawStar(g, rect, i < rating ? Brushes.Gold : Brushes.Gray);
            }
        }

        private void DrawStar(Graphics g, Rectangle rect, Brush brush)
        {
            PointF[] starPoints = new PointF[10];
            float cx = rect.X + rect.Width / 2f;
            float cy = rect.Y + rect.Height / 2f;
            float rOuter = rect.Width / 2f;
            float rInner = rOuter * 0.5f;

            for (int i = 0; i < 10; i++)
            {
                double angle = Math.PI / 5 * i;
                float r = i % 2 == 0 ? rOuter : rInner;
                starPoints[i] = new PointF(
                    cx + (float)(r * Math.Sin(angle)),
                    cy - (float)(r * Math.Cos(angle))
                );
            }

            g.FillPolygon(brush, starPoints);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            for (int i = 0; i < starRects.Length; i++)
            {
                if (starRects[i].Contains(e.Location))
                {
                    Ratings = i + 1;
                    RatingChanged?.Invoke(this, EventArgs.Empty);
                    break;
                }
            }
        }

        public event EventHandler SubmitButtonClicked;

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SubmitButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler RatingChanged;
    }
}

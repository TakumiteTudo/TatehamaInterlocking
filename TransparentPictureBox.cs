using System;
using System.Drawing;
using System.Windows.Forms;

public class TransparentPictureBox : PictureBox
{
    private bool isTransparent = true;

    public TransparentPictureBox()
    {
        // ダブルバッファリングを有効にしてちらつきを防ぐ
        this.SetStyle(ControlStyles.Opaque, true);
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        this.SetStyle(ControlStyles.UserPaint, true);
    }

    /// <summary>
    /// 透明状態を切り替えるフラグ。
    /// </summary>
    public bool IsView
    {
        get { return !isTransparent; }
        set
        {
            isTransparent = !value;
            this.Invalidate();
        }
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        if (!isTransparent)
        {
            base.OnPaintBackground(e);
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (isTransparent)
        {
            e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            e.Graphics.Clear(Color.Transparent);
        }
        base.OnPaint(e);
    }

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            if (isTransparent)
            {
                cp.ExStyle |= 0x20;  // WS_EX_TRANSPARENT
            }
            else
            {
                cp.ExStyle &= ~0x20; // Remove WS_EX_TRANSPARENT
            }
            return cp;
        }
    }
}
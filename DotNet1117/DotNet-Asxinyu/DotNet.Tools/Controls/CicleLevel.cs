/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-4-2
 * Time: 11:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D ;
using System.Windows.Forms;

namespace DotNet.Tools.Controls
{
	/// <summary>
	/// 油罐液位高度图像模块,可以设置半径和高度,进行填充
	/// </summary>
	public partial class CicleLevel : UserControl
	{
		public CicleLevel()
		{			
			InitializeComponent();			
		}
		
		public void DrawLevel(float R, float H)
		{
			Graphics gra = this.CreateGraphics();
			gra.Clear(Color.White);
			Brush bush = new SolidBrush(Color.Red);//填充的颜色
			Pen blackPen = new Pen(Color.Red , 2);
			
			float x =0;
			float y = 0;
			float width = 2*R ;
			float height = 2*R ;

            float startAngle = GetAngle(R, H);

            float sweepAngle;
            if (H  < R )
            {
                sweepAngle = 180 - 2 * startAngle;
            }
            else if (H == R)
            {
                sweepAngle = 180;
            }
            else
            {
                sweepAngle = 180 - 2 * startAngle;
            }

            gra.DrawEllipse(blackPen, x, y, width, height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, width, height, startAngle, sweepAngle);            
            gra.FillPath(bush, gp);
            gra.DrawPath(blackPen, gp);
        }

        //获取起始角度
        private float GetAngle(float R, float H)
        {
            if (H < R)
            {
                return (float)(Math.Asin(((double)(R - H))/(double)R) *180/Math.PI );
            }
            else if (R == H)
            {
                return 0;
            }
            else
            {
                return -(float)(Math.Asin(((double)(H - R)) / (double)R) * 180 / Math.PI);
            }
           
        }
	}
}
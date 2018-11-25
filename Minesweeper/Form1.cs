using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        SoundPlayer soundPlayer = new SoundPlayer(Minesweeper.Properties.Resources.Bomb_1);
        bool isLose = false;
        bool isAlreadyGameOver = false;
        int sec = 0, min = 0;
        bool isFirstClick = true;
        const int maxColCount = 30;
        const int maxRowCount = 24;
        int colCount = 10;
        int rowCount = 10;
        int remainingCell;
        int minesNumber = 10;
        int minesRemaining;
        MyButton[,] button;
        Cell[,] cell;
        Random randomizer = new Random();

        //Cell lưu thông tin của một ô.
        public struct Cell
        {
            public bool hasMine;
            public bool hasFlaged;
            public bool isOpened;
            public int mineCount;
            public int xCoord;
            public int yCoord;
        }

        public Form1()
        {
            InitializeComponent();
            SetSettingsData();           
            InitializeTheGame();
            CreateTheBoard();
        }

        //Gán giá trị của setting vào chương trình.
        void SetSettingsData()
        {
            colCount = Properties.Settings.Default.colCount;
            rowCount = Properties.Settings.Default.rowCount;
            minesNumber = Properties.Settings.Default.mineNumber;
        }

        //Rãi mìn ngẫu nhiên khi tạo bàn
        void RandomMine()
        {
            int temp = minesNumber;
            int cellCount = colCount * rowCount;
            List<int> mineArr = new List<int>(cellCount);
            for(int i = 0; i < cellCount; i++)
            {
                mineArr.Add(i);
            }
            while (temp > 0)
            {
                int randomIndex = randomizer.Next(mineArr.Count);
                int xCoord = mineArr[randomIndex] % colCount;
                int yCoord = mineArr[randomIndex] / colCount;
                cell[yCoord, xCoord].hasMine = true;
                mineArr.RemoveAt(randomIndex);
                temp--;
            }            
        }

        //Đếm số mìn trong 4 ô góc
        void CountMineInCorner()
        {
            if(cell[0, 0].hasMine == false)
                cell[0, 0].mineCount = (cell[1, 0].hasMine ? 1 : 0) + (cell[1, 1].hasMine ? 1 : 0) + (cell[0, 1].hasMine ? 1 : 0);
            if (cell[rowCount - 1, colCount - 1].hasMine == false)
                cell[rowCount - 1, colCount - 1].mineCount = (cell[rowCount - 1, colCount - 2].hasMine ? 1 : 0) + (cell[rowCount - 2, colCount - 2].hasMine ? 1 : 0) + (cell[rowCount - 2, colCount - 1].hasMine ? 1 : 0);
            if (cell[0, colCount - 1].hasMine == false)
                cell[0, colCount - 1].mineCount = (cell[0, colCount - 2].hasMine ? 1 : 0) + (cell[1, colCount - 2].hasMine ? 1 : 0) + (cell[1, colCount - 1].hasMine ? 1 : 0);
            if (cell[rowCount - 1, 0].hasMine == false)
                cell[rowCount - 1, 0].mineCount = (cell[rowCount - 1, 1].hasMine ? 1 : 0) + (cell[rowCount - 2, 1].hasMine ? 1 : 0) + (cell[rowCount - 2, 0].hasMine ? 1 : 0);
        }

        //Đếm số mìn lân cận của tất cả ô.
        void NeighborMineCount()
        {
            List<int> factor = new List<int> { -1, 0, 1 };
            for(int y = 1; y < rowCount - 1; y++)
            {
                for(int x = 1; x < colCount - 1; x++)
                {
                    cell[y, x].mineCount = 0;
                    if(cell[y, x].hasMine == false)
                    {
                        foreach (int i in factor)
                            foreach (int j in factor)
                            {
                                if (i != 0 || j != 0)                                
                                    if (cell[y + i, x + j].hasMine == true)
                                        cell[y, x].mineCount++;                                
                            }
                    }
                }
            }
            CountMineInCorner();
            for(int x = 1; x < colCount - 1; x++)
            {
                cell[0, x].mineCount = (cell[0, x - 1].hasMine ? 1 : 0) + (cell[1, x - 1].hasMine ? 1 : 0) + (cell[1, x].hasMine ? 1 : 0) + (cell[1, x + 1].hasMine ? 1 : 0) + (cell[0, x + 1].hasMine ? 1 : 0);
                cell[rowCount - 1, x].mineCount = (cell[rowCount - 1, x - 1].hasMine ? 1 : 0) + (cell[rowCount - 2, x - 1].hasMine ? 1 : 0) + (cell[rowCount - 2, x].hasMine ? 1 : 0) + (cell[rowCount - 2, x + 1].hasMine ? 1 : 0) + (cell[rowCount - 1, x + 1].hasMine ? 1 : 0);
            }
            for(int y = 1; y < rowCount - 1; y++)
            {
                cell[y, 0].mineCount = (cell[y - 1, 0].hasMine ? 1 : 0) + (cell[y - 1, 1].hasMine ? 1 : 0) + (cell[y, 1].hasMine ? 1 : 0) + (cell[y + 1, 1].hasMine ? 1 : 0) + (cell[y + 1, 0].hasMine ? 1 : 0);
                cell[y, colCount - 1].mineCount = (cell[y - 1, colCount - 1].hasMine ? 1 : 0) + (cell[y - 1, colCount - 2].hasMine ? 1 : 0) + (cell[y, colCount - 2].hasMine ? 1 : 0) + (cell[y + 1, colCount - 2].hasMine ? 1 : 0) + (cell[y + 1, colCount - 1].hasMine ? 1 : 0);
            }
        }

        //Tạo bàn, gán thông tin cho từng cell.
        void InitializeTheGame()
        {
            button = new MyButton[maxRowCount, maxColCount];
            cell = new Cell[maxRowCount, maxColCount];
            remainingCell = rowCount * colCount - minesNumber;
            this.Size = new Size(colCount * 21 + 42, rowCount * 21 + 40 + 70 + 20);
            minesRemaining = minesNumber;
            mineCountLbl.Text = minesRemaining.ToString();
            for (int y = 0; y < maxRowCount; y++)
            {
                for (int x = 0; x < maxColCount; x++)
                {
                    button[y, x] = new MyButton();
                    button[y, x].Width = 21;
                    button[y, x].Height = 21;
                    button[y, x].Location = new Point(x * 21 + 10, y * 21 + 30);                   
                    
                    cell[y, x].hasFlaged = false;
                    cell[y, x].hasMine = false;
                    cell[y, x].isOpened = false;
                    cell[y, x].mineCount = 0;
                    cell[y, x].xCoord = x;
                    cell[y, x].yCoord = y;
                }
            }
        }

        //Rãi mìn, đếm số mìn lân cận, gán cell vào ô tương ứng.
        void CreateTheBoard()
        {            
            for (int y = 0; y < rowCount; y++)
            {
                for (int x = 0; x < colCount; x++)
                {
                    button[y, x].MouseUp += Button_Click;
                    button[y, x].Parent = panel1;               
                }
            }
            RandomMine();
            NeighborMineCount();
            for(int y = 0; y < rowCount; y++)
            {
                for(int x = 0; x < colCount; x++)
                {
                    button[y, x].Tag = cell[y, x];
                }
            }            
        }

        //Khi click chuột trái vào 1 ô.
        void LeftClickOnCell(int x, int y)
        {
            if (x < 0 || x > colCount - 1 || y < 0 || y > rowCount - 1)
                return;
            
            //Nếu ô chưa mở và chưa có cờ thì mở ô đó.
            if(cell[y, x].isOpened == false && cell[y, x].hasFlaged == false)
            {
                cell[y, x].isOpened = true;

                //Bỏ sự kiện click chuột trái và thêm sự kiện double click.
                button[y, x].MouseUp -= Button_Click;          
                button[y, x].DoubleClick += Button_DoubleClick;

                button[y, x].BackColor = Color.AntiqueWhite;
                
                //Nếu ô đó không có mìn.
                if (cell[y, x].hasMine == false)
                {
                    remainingCell--;
                    
                    //Nếu các ô xung quanh ô đó cũng không có mìn,
                    //thì gọi lại hàm trên các ô xung quanh đó.
                    if (cell[y, x].mineCount != 0)
                        button[y, x].Text = cell[y, x].mineCount.ToString();
                    else
                    {
                        LeftClickOnCell(x - 1, y - 1);
                        LeftClickOnCell(x, y - 1);
                        LeftClickOnCell(x + 1, y - 1);
                        LeftClickOnCell(x - 1, y);
                        LeftClickOnCell(x + 1, y);
                        LeftClickOnCell(x - 1, y + 1);
                        LeftClickOnCell(x, y + 1);
                        LeftClickOnCell(x + 1, y + 1);
                    }                    
                }
                else
                {
                    isLose = true;
                    GameOver();
                }
            }
        }

        //Kiểm tra chiến thắng.
        void CheckForWinner(int x, int y)
        {
            if (remainingCell == 0 && cell[y, x].hasMine == false)
            {
                MessageBox.Show("You Won!!\nTime: " + (min * 60 + sec).ToString() + " seconds");
                GameOver();
            }
        }

        //Lần chọn đầu tiên không thể thua.
        //Nếu lần đầu chọn trúng ô có mìn,
        //đưa mìn lên ô góc trên bên trái cùng nhất.
        void PreventLoseOnFirstClick(int x, int y)
        {
            if (cell[y, x].hasMine == true)
            {                
                for(int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < colCount; j++)
                    {
                        if (cell[i, j].hasMine == false)
                        {
                            cell[i, j].hasMine = true;
                            cell[y, x].hasMine = false;
                            
                            //Đếm lại số mìn lân cận nếu có sự thay đổi vị trí mìn.
                            NeighborMineCount();
                            return;
                        }
                    }                   
                }
            }
            //Đếm giờ sau khi click lần đầu tiên.
            timer1.Start();            
        }

        //Thua khi click vào ô có mìn.
        void GameOver()
        {
            if (isLose)
                //Bùm!!
                soundPlayer.Play();
            isAlreadyGameOver = true;

            //Dừng đồng hồ.
            timer1.Stop();
            for(int y = 0; y < rowCount; y++)
            {
                for(int x = 0; x < colCount; x++)
                {
                    //Nếu ô có mìn thì hiện mìn ô đó lên.
                    if (cell[y, x].hasMine == true)
                    {
                        //button[y, x].MouseUp -= Button_Click;
                        button[y, x].Image = Properties.Resources.mine;
                        button[y, x].BackColor = Color.AntiqueWhite;
                    }
                    //Nếu ô đó không có mìn mà có cờ thì hiện hình mìn bị gạch chéo. 
                    else if (cell[y,x].hasFlaged == true)
                    {
                        button[y, x].Image = Properties.Resources.mine_crossed;
                        button[y, x].BackColor = Color.AntiqueWhite;
                    }
                    //Lấy các sự kiện click của các ô.
                    if (cell[y, x].isOpened == false)
                        button[y, x].MouseUp -= Button_Click;
                    else button[y, x].DoubleClick -= Button_DoubleClick;
                }
            }
        }

        void Restart()
        {
            minesRemaining = minesNumber;
            mineCountLbl.Text = minesRemaining.ToString();
            isLose = false;
            isAlreadyGameOver = false;
            remainingCell = rowCount * colCount - minesNumber;

            //Reset thời gian.
            min = 0;
            sec = 0;
            timerLbl.Text = min + ":0" + sec;

            //Reset lại các thông số của trò chơi.
            for (int y = 0; y < rowCount; y++)
            {
                for (int x = 0; x < colCount; x++)
                {
                    button[y, x].Text = "";
                    button[y, x].Image = null;
                    button[y, x].BackToNormal();
                    button[y, x].MouseUp += Button_Click;
                    cell[y, x].hasFlaged = false;
                    cell[y, x].hasMine = false;
                    cell[y, x].isOpened = false;
                    cell[y, x].mineCount = 0;
                }
            }
            isFirstClick = true;
            RandomMine();
            NeighborMineCount();
            for (int y = 0; y < rowCount; y++)
            {
                for (int x = 0; x < colCount; x++)
                {
                    button[y, x].Tag = cell[y, x];
                }
            }
        }

        void Button_Click(object sender, MouseEventArgs e)
        {
            
            Button btn = sender as Button;            
            Cell temp = (Cell)btn.Tag;

            //Lấy tọa độ của ô vừa click.
            int x = temp.xCoord;
            int y = temp.yCoord;

            if (e.Button == MouseButtons.Left)
            {
                //Nếu là lần click đầu tiên.
                if (isFirstClick == true)
                {
                    PreventLoseOnFirstClick(x, y);
                    isFirstClick = false;
                }
                //Gọi hàm click cho chuột trái.
                LeftClickOnCell(x, y);
                CheckForWinner(x, y);
            }
            //Đặt cờ cho chuột phải.
            else if (e.Button == MouseButtons.Right)
            {
                if (cell[y, x].isOpened == false)
                {
                    if (cell[y, x].hasFlaged == false)
                    {                        
                        minesRemaining--;
                        mineCountLbl.Text = minesRemaining.ToString();
                        btn.Image = Properties.Resources.flag;
                        cell[y, x].hasFlaged = true;
                    }
                    else
                    {
                        minesRemaining++;
                        mineCountLbl.Text = minesRemaining.ToString();
                        btn.Image = null;
                        cell[y, x].hasFlaged = false;
                    }
                }
            }
            
        }

        int FlagCount(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < colCount && y < rowCount)
            {
                if (cell[y, x].hasFlaged == true)
                    return 1;
                else return 0;
            }                
            else return 0;
        }

        //Đếm số cờ xung quanh của một ô.
        int CountNeighborFlag(int x, int y)
        {
            int flagCount = 0;
            List<int> factor = new List<int> { -1, 0, 1 };
            foreach (int i in factor)
                foreach (int j in factor)
                {
                    if (i != 0 || j != 0)
                        flagCount += FlagCount(x + j, y + i);
                }
            return flagCount;
        }

        //Khi số cờ xung quanh của 1 ô bằng với số mìn lân cận của ô đó,
        //Double click vào 1 ô sẽ tự động mở các ô xung quanh còn lại (các ô không có cờ).
        private void Button_DoubleClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Cell temp = (Cell)btn.Tag;

            //Lấy tọa độ của ô vừa click.
            int x = temp.xCoord;
            int y = temp.yCoord;

            if (CountNeighborFlag(x, y) == cell[y, x].mineCount)
            {
                LeftClickOnCell(x - 1, y - 1);
                LeftClickOnCell(x - 1, y);
                LeftClickOnCell(x - 1, y + 1);
                LeftClickOnCell(x, y - 1);
                LeftClickOnCell(x, y + 1);
                LeftClickOnCell(x + 1, y - 1);
                LeftClickOnCell(x + 1, y);
                LeftClickOnCell(x + 1, y + 1);
            }                           
            CheckForWinner(x, y);
        }

        //Khi ấn vào nút restart.
        private void resBtn_Click(object sender, EventArgs e)
        {
            //Nếu ấn nút restart trước khi thua, gần phải gọi Gameover()
            //để dọn dẹp các sự kiện click.
            if(isAlreadyGameOver == false)
                GameOver();
            Restart();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Khi click vào Settings.
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.TransferSettingsData += form2_TransferSettingsData;
            form2.ShowDialog();
        }

        private void form2_TransferSettingsData(object sender, EventArgs e)
        {
            int newColCount = Properties.Settings.Default.colCount;
            int newRowCount = Properties.Settings.Default.rowCount;
            minesNumber = Properties.Settings.Default.mineNumber;
            //Thêm hoặc bớt các ô khi thay đổi kích thước bàn chơi.
            if ((newColCount == colCount) && (newRowCount == rowCount))
            {
                if (isAlreadyGameOver == false)
                    GameOver();
                Restart();
            }
            else
            {
                if(rowCount < newRowCount && colCount < newColCount)
                {
                    for(int y = 0; y < rowCount; y++)
                    {
                        for(int x = colCount; x < newColCount; x++)
                        {
                            panel1.Controls.Add(button[y, x]);
                        }
                    }
                    for(int y = rowCount; y < newRowCount; y++)
                    {
                        for(int x = 0; x < newColCount; x++)
                        {
                            panel1.Controls.Add(button[y, x]);
                        }
                    }
                }
                else if (rowCount >= newRowCount && colCount >= newColCount)
                {
                    for(int y = 0; y < newRowCount; y++)
                    {
                        for(int x = newColCount; x < colCount; x++)
                        {
                            panel1.Controls.Remove(button[y, x]);
                        }
                    }
                    for(int y = newRowCount; y < rowCount; y++)
                    {
                        for(int x = 0; x < colCount; x++)
                        {
                            panel1.Controls.Remove(button[y, x]);
                        }
                    }
                }
                else if (newColCount <= colCount && newRowCount >= rowCount)
                {
                    for(int y = 0; y < rowCount; y++)
                    {
                        for(int x = newColCount; x < colCount; x++)
                        {
                            panel1.Controls.Remove(button[y, x]);
                        }
                    }
                    for(int y = rowCount; y < newRowCount; y++)
                    {
                        for(int x = 0; x < newColCount; x++)
                        {
                            panel1.Controls.Add(button[y, x]);
                        }
                    }
                }
                else
                {
                    for(int y = 0; y < newRowCount; y++)
                    {
                        for(int x = colCount; x < newColCount; x++)
                        {
                            panel1.Controls.Add(button[y, x]);
                        }
                    }
                    for(int y = newRowCount; y < rowCount; y++)
                    {
                        for(int x = 0; x < colCount; x++)
                        {
                            panel1.Controls.Remove(button[y, x]);
                        }
                    }
                }
                if (isAlreadyGameOver == false)
                    GameOver();
                colCount = newColCount;
                rowCount = newRowCount;
                this.Size = new Size(colCount * 21 + 42, rowCount * 21 + 40 + 70 + 20);                
                Restart();
            }            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        //Sự kiện đếm giờ.
        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec == 60)
            {
                sec = 0;
                min++;
            }
            if (sec < 10)
            {
                timerLbl.Text = min + ":0" + sec;
            }
            if (sec >= 10 && sec < 60)
            {
                timerLbl.Text = min + ":" + sec;
            }            
        }
    }
}

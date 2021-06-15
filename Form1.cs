using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using System.Media;

namespace elevator_zzy
{
    public partial class Form1 : Form
    {
        
        List<Button> buttons_select_ele = new List<Button>();//电梯按钮初
        public List<Button> buttons_in_ele = new List<Button>();//电梯内按钮
        public List<Button> buttons_up_floor = new List<Button>();//楼层上按钮
        public List<Button> buttons_down_floor = new List<Button>();//楼层下按钮
        List<Label> label_ele1 = new List<Label>();//
        List<Label> label_ele2 = new List<Label>();//
        List<Label> label_ele3 = new List<Label>();//
        List<Label> label_ele4 = new List<Label>();//
        List<Label> label_ele5 = new List<Label>();//
        public List<List<Label>> label_ele = new List<List<Label>>();//电梯1-5标签
        public List<Elevator> Elevators = new List<Elevator>();//电梯列表
        public List<int> stop_count = new List<int>();//倒计时，用于开门
        public List<Timer> Timers = new List<Timer>();//五部电梯分别设置定时器
        public Color default_color;//
        public int current_control_ele = 6;//当前控制的电梯ID
        public List<List<int>> pushed_button_in_ele = new List<List<int>>();//电梯内按钮是否按下标记
        public List<Label> ele_text_label = new List<Label>();
        

        public Form1()
        {
            InitializeComponent();
            //选择电梯按钮初始化
            buttons_select_ele.Add(elevator1_button);
            buttons_select_ele.Add(elevator2_button);
            buttons_select_ele.Add(elevator3_button);
            buttons_select_ele.Add(elevator4_button);
            buttons_select_ele.Add(elevator5_button);
            //电梯内按钮初始化
            buttons_in_ele.Add(xiangling);//响铃凑数
            buttons_in_ele.Add(button_floor1);
            buttons_in_ele.Add(button_floor2);
            buttons_in_ele.Add(button_floor3);
            buttons_in_ele.Add(button_floor4);
            buttons_in_ele.Add(button_floor5);
            buttons_in_ele.Add(button_floor6);
            buttons_in_ele.Add(button_floor7);
            buttons_in_ele.Add(button_floor8);
            buttons_in_ele.Add(button_floor9);
            buttons_in_ele.Add(button_floor10);
            buttons_in_ele.Add(button_floor11);
            buttons_in_ele.Add(button_floor12);
            buttons_in_ele.Add(button_floor13);
            buttons_in_ele.Add(button_floor14);
            buttons_in_ele.Add(button_floor15);
            buttons_in_ele.Add(button_floor16);
            buttons_in_ele.Add(button_floor17);
            buttons_in_ele.Add(button_floor18);
            buttons_in_ele.Add(button_floor19);
            buttons_in_ele.Add(button_floor20);
            //初始化楼层上按钮
            buttons_up_floor.Add(xiangling);//响铃凑数
            buttons_up_floor.Add(button_up_floor1);
            buttons_up_floor.Add(button_up_floor2);
            buttons_up_floor.Add(button_up_floor3);
            buttons_up_floor.Add(button_up_floor4);
            buttons_up_floor.Add(button_up_floor5);
            buttons_up_floor.Add(button_up_floor6);
            buttons_up_floor.Add(button_up_floor7);
            buttons_up_floor.Add(button_up_floor8);
            buttons_up_floor.Add(button_up_floor9);
            buttons_up_floor.Add(button_up_floor10);
            buttons_up_floor.Add(button_up_floor11);
            buttons_up_floor.Add(button_up_floor12);
            buttons_up_floor.Add(button_up_floor13);
            buttons_up_floor.Add(button_up_floor14);
            buttons_up_floor.Add(button_up_floor15);
            buttons_up_floor.Add(button_up_floor16);
            buttons_up_floor.Add(button_up_floor17);
            buttons_up_floor.Add(button_up_floor18);
            buttons_up_floor.Add(button_up_floor19);
            //初始化楼层下按钮
            buttons_down_floor.Add(xiangling);//响铃凑数
            buttons_down_floor.Add(xiangling);//响铃凑数
            buttons_down_floor.Add(button37);
            buttons_down_floor.Add(button35);
            buttons_down_floor.Add(button33);
            buttons_down_floor.Add(button31);
            buttons_down_floor.Add(button29);
            buttons_down_floor.Add(button27);
            buttons_down_floor.Add(button25);
            buttons_down_floor.Add(button23);
            buttons_down_floor.Add(button21);
            buttons_down_floor.Add(button19);
            buttons_down_floor.Add(button17);
            buttons_down_floor.Add(button15);
            buttons_down_floor.Add(button13);
            buttons_down_floor.Add(button11);
            buttons_down_floor.Add(button9);
            buttons_down_floor.Add(button7);
            buttons_down_floor.Add(button5);
            buttons_down_floor.Add(button3);
            buttons_down_floor.Add(button1);
            //初始化电梯状态标签
            label_ele1.Add(label1);//凑数
            label_ele1.Add(label_ele1_floor1);
            label_ele1.Add(label_ele1_floor2);
            label_ele1.Add(label_ele1_floor3);
            label_ele1.Add(label_ele1_floor4);
            label_ele1.Add(label_ele1_floor5);
            label_ele1.Add(label_ele1_floor6);
            label_ele1.Add(label_ele1_floor7);
            label_ele1.Add(label_ele1_floor8);
            label_ele1.Add(label_ele1_floor9);
            label_ele1.Add(label_ele1_floor10);
            label_ele1.Add(label_ele1_floor11);
            label_ele1.Add(label_ele1_floor12);
            label_ele1.Add(label_ele1_floor13);
            label_ele1.Add(label_ele1_floor14);
            label_ele1.Add(label_ele1_floor15);
            label_ele1.Add(label_ele1_floor16);
            label_ele1.Add(label_ele1_floor17);
            label_ele1.Add(label_ele1_floor18);
            label_ele1.Add(label_ele1_floor19);
            label_ele1.Add(label_ele1_floor20);
            label_ele2.Add(label1);//凑数
            label_ele2.Add(label29);
            label_ele2.Add(label30);
            label_ele2.Add(label31);
            label_ele2.Add(label32);
            label_ele2.Add(label33);
            label_ele2.Add(label34);
            label_ele2.Add(label35);
            label_ele2.Add(label36);
            label_ele2.Add(label37);
            label_ele2.Add(label38);
            label_ele2.Add(label39);
            label_ele2.Add(label40);
            label_ele2.Add(label41);
            label_ele2.Add(label42);
            label_ele2.Add(label43);
            label_ele2.Add(label44);
            label_ele2.Add(label45);
            label_ele2.Add(label46);
            label_ele2.Add(label47);
            label_ele2.Add(label48);
            label_ele3.Add(label1);//凑数
            label_ele3.Add(label49);
            label_ele3.Add(label50);
            label_ele3.Add(label51);
            label_ele3.Add(label52);
            label_ele3.Add(label53);
            label_ele3.Add(label54);
            label_ele3.Add(label55);
            label_ele3.Add(label56);
            label_ele3.Add(label57);
            label_ele3.Add(label58);
            label_ele3.Add(label59);
            label_ele3.Add(label60);
            label_ele3.Add(label61);
            label_ele3.Add(label62);
            label_ele3.Add(label63);
            label_ele3.Add(label64);
            label_ele3.Add(label65);
            label_ele3.Add(label66);
            label_ele3.Add(label67);
            label_ele3.Add(label68);
            label_ele4.Add(label1);//凑数
            label_ele4.Add(label69);
            label_ele4.Add(label70);
            label_ele4.Add(label71);
            label_ele4.Add(label72);
            label_ele4.Add(label73);
            label_ele4.Add(label74);
            label_ele4.Add(label75);
            label_ele4.Add(label76);
            label_ele4.Add(label77);
            label_ele4.Add(label78);
            label_ele4.Add(label79);
            label_ele4.Add(label80);
            label_ele4.Add(label81);
            label_ele4.Add(label82);
            label_ele4.Add(label83);
            label_ele4.Add(label84);
            label_ele4.Add(label85);
            label_ele4.Add(label86);
            label_ele4.Add(label87);
            label_ele4.Add(label88);
            label_ele5.Add(label1);//凑数
            label_ele5.Add(label89);
            label_ele5.Add(label90);
            label_ele5.Add(label91);
            label_ele5.Add(label92);
            label_ele5.Add(label93);
            label_ele5.Add(label94);
            label_ele5.Add(label95);
            label_ele5.Add(label96);
            label_ele5.Add(label97);
            label_ele5.Add(label98);
            label_ele5.Add(label99);
            label_ele5.Add(label100);
            label_ele5.Add(label101);
            label_ele5.Add(label102);
            label_ele5.Add(label103);
            label_ele5.Add(label104);
            label_ele5.Add(label105);
            label_ele5.Add(label106);
            label_ele5.Add(label107);
            label_ele5.Add(label108);
            label_ele.Add(label_ele1);
            label_ele.Add(label_ele2);
            label_ele.Add(label_ele3);
            label_ele.Add(label_ele4);
            label_ele.Add(label_ele5);
            ele_text_label.Add(label24);
            ele_text_label.Add(label25);
            ele_text_label.Add(label26);
            ele_text_label.Add(label27);
            ele_text_label.Add(label28);

            //初始化Elevators
            for (int i = 0; i < 5; i++)
            {
                Elevators.Add(new Elevator(i,this));
                stop_count.Add(0);
            }
            //初始化计时器
            setTimer();
            default_color = xiangling.BackColor;
            //绑定上按钮事件
            for (int i = 1; i <= 19; i++)
            {
                buttons_up_floor[i].Click += new System.EventHandler(this.button_up_Click);
            }
            //绑定下按钮事件
            for (int i = 2; i <= 20; i++)
            {
                buttons_down_floor[i].Click += new System.EventHandler(this.button_down_Click);
            }
            //初始化电梯内按钮pushed
            for (int j = 0; j < 5; j++)
            {
                pushed_button_in_ele.Add(new List<int>());
                for (int i = 0; i < 21; i++)
                {
                    pushed_button_in_ele[j].Add(0);
                }
            }
            //初始化电梯内按钮
            for (int i = 1; i <= 20; i++)
            {
                buttons_in_ele[i].Click += new System.EventHandler(this.push_button_in_ele);
            }
        }

        //初始化计时器
        public void setTimer()
        {
            for (int i = 0; i < 5; i++)
            {
                Timers.Add(new Timer());
                Timers[i].Interval = 500;
                Timers[i].Tick += new EventHandler(run);
            }
        }

        //电梯运行函数，用于计时器调用
        private void run(object sender, EventArgs e)
        {
            Elevators[Timers.IndexOf(sender as Timer)].run(this);
        }

        //用于电梯内按钮触发
        private void push_button_in_ele(object sender, EventArgs e)
        {
            if (current_control_ele == 6)
            {
                MessageBox.Show("请先在左上角部分选择您要控制的电梯！","来自Zzy的温馨提示");
                return;
            }
            int floor = buttons_in_ele.IndexOf(sender as Button);
            Task task = new Task();
            task.floor = floor;
            task.to_state = 0;

            //防止重复分配任务（按钮已经处于按下状态时不再将新产生的任务进行调度，也就是丢弃该任务）
            if (pushed_button_in_ele[current_control_ele][floor]==1)
            {
                return;
            }
            if (Elevators[current_control_ele].current_floor == floor && stop_count[current_control_ele] > 0)
            {
                return;
            }
            if (Elevators[current_control_ele].tasks.Exists(taski => taski.floor == task.floor && taski.to_state == task.to_state))
            {
                return;
            }
            
            pushed_button_in_ele[current_control_ele][floor] = 1;
            (sender as Button).BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            Elevators[current_control_ele].tasks.Add(task);
            Timers[current_control_ele].Start();
        }

        //对应五个电梯选择按钮，选择当前控制的电梯
        private void select_Current_ele(object sender, EventArgs e)
        {
            current_control_ele = buttons_select_ele.IndexOf(sender as Button);
            foreach (Button element in buttons_select_ele)
            {
                element.BackColor = default_color;
                //element.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            }
            (sender as Button).BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            label1.Text = "当前控制电梯"+(current_control_ele + 1).ToString();
            for (int i = 1; i <= 20; i++)
            {
                if (pushed_button_in_ele[current_control_ele][i] == 0)
                {
                    buttons_in_ele[i].BackColor = default_color;
                }
                else
                {
                    buttons_in_ele[i].BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                }
            }
        }

        //各楼层上键触发，外调度，逻辑见文档
        private void button_up_Click(object sender, EventArgs e)
        {
            int floor = buttons_up_floor.IndexOf(sender as Button);
            Task task = new Task();
            task.floor = floor;
            task.to_state = 1;

            //防止重复分配任务（按钮已经处于按下状态时不再将新产生的任务进行调度，也就是丢弃该任务）
            if ((sender as Button).BackgroundImage == global::elevator_zzy.Properties.Resources.upgreentransplant)
            {
                return;
            }
            for (int i = 0; i < 5; i++)
            {
                if (Elevators[i].current_floor == floor && stop_count[i] > 0)
                {
                    return;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (Elevators[i].tasks.Exists(taski => taski.floor == task.floor && taski.to_state == task.to_state))
                {
                    return;
                }
            }

            int mindst=100, minele = 0;
            for (int i = 0; i < 5; i++)
            {
                if (Elevators[i].move_state == 1)
                {
                    if (Elevators[i].current_floor <= floor)
                    {
                        if (mindst > floor - Elevators[i].current_floor + 5 * Elevators[i].tasks.Count())
                        {
                            mindst = floor - Elevators[i].current_floor + 5 * Elevators[i].tasks.Count();
                            minele = i;
                        }
                    }
                    else
                    {
                        if (mindst > (-floor - Elevators[i].current_floor + 2 * 20) + 5 * Elevators[i].tasks.Count())
                        {
                            mindst = -floor - Elevators[i].current_floor + 2 * 20 + 5 * Elevators[i].tasks.Count();
                            minele = i;
                        }
                    }
                }
                else if (Elevators[i].move_state == -1)
                {
                    if (mindst > (floor + Elevators[i].current_floor) + 5 * Elevators[i].tasks.Count())
                    {
                        mindst = floor + Elevators[i].current_floor + 5 * Elevators[i].tasks.Count();
                        minele = i;
                    }
                }
                else
                {
                    if (mindst > ((-floor + Elevators[i].current_floor) > 0 ? (-floor + Elevators[i].current_floor) + 5 * Elevators[i].tasks.Count() : (floor - Elevators[i].current_floor) + 5 * Elevators[i].tasks.Count()))
                    {
                        mindst = ((-floor + Elevators[i].current_floor) > 0 ? (-floor + Elevators[i].current_floor) + 5 * Elevators[i].tasks.Count() : (floor - Elevators[i].current_floor) + 5 * Elevators[i].tasks.Count());
                        minele = i;
                    }
                }
            }
            Elevators[minele].tasks.Add(task);
            Timers[minele].Start();
            //Elevators[current_control_ele].tasks.Add(task);
            //Timers[current_control_ele].Start();
            (sender as Button).BackgroundImage = global::elevator_zzy.Properties.Resources.upgreentransplant;
        }

        //各楼层下键触发，外调度，逻辑见文档
        private void button_down_Click(object sender, EventArgs e)
        {
            int floor = buttons_down_floor.IndexOf(sender as Button);
            Task task = new Task();
            task.floor = floor;
            task.to_state = -1;

            //防止重复分配任务（按钮已经处于按下状态时不再将新产生的任务进行调度，也就是丢弃该任务）
            if ((sender as Button).BackgroundImage == global::elevator_zzy.Properties.Resources.downgreentransplant)
            {
                return;
            }
            for (int i = 0; i < 5; i++)
            {
                if (Elevators[i].current_floor == floor && stop_count[i] > 0)
                {
                    return;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (Elevators[i].tasks.Exists(taski => taski.floor== task.floor && taski.to_state == task.to_state))
                {
                    return;
                }
            }

            int mindst = 1000, minele = 0;
            for (int i = 0; i < 5; i++)
            {
                if (Elevators[i].move_state == -1)
                {
                    if (Elevators[i].current_floor >= floor)
                    {
                        if (mindst > +5* Elevators[i].tasks.Count() - floor + Elevators[i].current_floor)
                        {
                            mindst = -floor + Elevators[i].current_floor + 5 * Elevators[i].tasks.Count();
                            minele = i;
                        }
                    }
                    else
                    {
                        if (mindst > (floor + Elevators[i].current_floor + 5 * Elevators[i].tasks.Count()))
                        {
                            mindst = floor + Elevators[i].current_floor + 5 * Elevators[i].tasks.Count();
                            minele = i;
                        }
                    }
                }
                else if (Elevators[i].move_state == 1)
                {
                    if (mindst > 40 - floor - Elevators[i].current_floor + 5 * Elevators[i].tasks.Count())
                    {
                        mindst = 40 - floor - Elevators[i].current_floor + 5 * Elevators[i].tasks.Count();
                        minele = i;
                    }
                }
                else
                {
                    if (mindst > ((-floor + Elevators[i].current_floor) > 0 ? (-floor + Elevators[i].current_floor + 5 * Elevators[i].tasks.Count()) : (floor - Elevators[i].current_floor + 5 * Elevators[i].tasks.Count())))
                    {
                        mindst = ((-floor + Elevators[i].current_floor) > 0 ? (-floor + Elevators[i].current_floor + 5 * Elevators[i].tasks.Count()) : (floor - Elevators[i].current_floor + 5 * Elevators[i].tasks.Count()));
                        minele = i;
                    }
                }
            }
            Elevators[minele].tasks.Add(task);
            Timers[minele].Start();
            //Elevators[current_control_ele].tasks.Add(task);
            //Timers[current_control_ele].Start();
            (sender as Button).BackgroundImage = global::elevator_zzy.Properties.Resources.downgreentransplant;
        }
        
        //开门按钮触发
        private void button_opendoor_Click(object sender, EventArgs e)
        {
            if (current_control_ele == 6)
            {
                MessageBox.Show("请先在左上角部分选择您要控制的电梯！", "来自Zzy的温馨提示");
                return;
            }
            if (Elevators[current_control_ele].move_state == 0)
            {
                Timers[current_control_ele].Start();
                open_door(Elevators[current_control_ele]);
            }
        }

        //关门按钮触发
        private void button_closedoor_Click(object sender, EventArgs e)
        {
            if (current_control_ele == 6)
            {
                MessageBox.Show("请先在左上角部分选择您要控制的电梯！", "来自Zzy的温馨提示");
                return;
            }
            stop_count[current_control_ele] = 1;
        }

        //报警按钮触发
        private void callpolice_Click(object sender, EventArgs e)
        {
            MessageBox.Show("已经帮你报警了，请耐心等待救援\n切勿盲目自救!!!","Zzy对你说");
        }

        //响铃按钮触发
        private void xiangling_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
        }

        public void open_door(Elevator ele)
        {
            int no = Elevators.IndexOf(ele);
            stop_count[no] = 5;
            label_ele[no][ele.current_floor].BackColor = Color.PaleGreen;
        }

        public void close_door(Elevator ele)
        {
            int no = Elevators.IndexOf(ele);
            label_ele[no][ele.current_floor].BackColor = Color.Salmon;//找不到control这个颜色
        }
    }


    public class Elevator
    {
        public int id;//电梯编号
        public int current_floor = 0;//电梯当前所处楼层
        public int move_state = 0;//电梯的当前状态（下一时刻即将拥有的状态）0等待态 1上行 -1下行
        public List<Task> tasks = new List<Task>();//任务队列

        public Elevator(int id, Form1 Form1)
        {
            this.id = id;
            move_to_floor(1, Form1);
        }

        //内调度，选择当前要执行的任务
        //move_state等于零，电梯处于等待状态，返回当前要执行的任务
        //move_state = 1或-1，返回当前要执行的任务，若没有该方向的任务返回一个state=2的不合法task
        Task best_task()
        {
            int mindist_up = 100, mindist_down = 100;
            int maxdist_up = -1, maxdist_down = -1;
            Task best_task_up = new Task(), best_task_down = new Task();//当前最应该执行的task
            switch (move_state)
            {

                case 0://电梯的状态为停止等待
                    //首先检查电梯内的到达任务
                    foreach (Task taski in tasks)
                    {
                        if (taski.to_state == 0)
                        {
                            if (taski.floor >= current_floor)
                            {
                                if (mindist_up > taski.floor - current_floor)
                                {
                                    mindist_up = taski.floor - current_floor;
                                    best_task_up = taski;
                                }
                            }
                            else
                            {
                                if (mindist_down > -taski.floor + current_floor)
                                {
                                    mindist_down = -taski.floor + current_floor;
                                    best_task_down = taski;
                                }
                            }
                        }
                    }
                    if (mindist_up < 100 || mindist_down < 100)
                    {
                        return mindist_up < mindist_down ? best_task_up : best_task_down;
                    }
                    //没有到达任务的情况下检查电梯外任务
                    foreach (Task taski in tasks)
                    {
                        if (taski.floor >= current_floor)
                        {
                            if (mindist_up > taski.floor - current_floor)
                            {
                                mindist_up = taski.floor - current_floor;
                                best_task_up = taski;
                            }
                        }
                        else
                        {
                            if (mindist_down > -taski.floor + current_floor)
                            {
                                mindist_down = -taski.floor + current_floor;
                                best_task_down = taski;
                            }
                        }
                    }
                    return mindist_up < mindist_down ? best_task_up : best_task_down;
                case 1://电梯状态为向上
                    //首先搜索在本楼层以上并且向上的任务以及到达任务
                    foreach (Task taski in tasks)
                    {
                        if (taski.to_state >= 0)
                        {
                            if (taski.floor >= current_floor)
                            {
                                if (mindist_up > taski.floor - current_floor)
                                {
                                    mindist_up = taski.floor - current_floor;
                                    best_task_up = taski;
                                }
                            }
                        }
                    }
                    if (mindist_up < 100) { return best_task_up; }
                    //再搜索在本楼层以上并且向下的任务，挑最远的
                    foreach (Task taski in tasks)
                    {
                        if (taski.floor >= current_floor)
                        {
                            if (maxdist_up < taski.floor - current_floor)
                            {
                                maxdist_up = taski.floor - current_floor;
                                best_task_up = taski;
                            }
                        }
                    }
                    if (maxdist_up != -1) {
                       
                        return best_task_up; }
                    //没有需要向上走的任务
                    //MessageBox.Show("66");
                    return new Task();//没有向上走的任务时返回非法值
                case -1://电梯状态为向下
                    //首先搜索在本楼层以下并且向下的任务以及到达任务
                    foreach (Task taski in tasks)
                    {
                        if (taski.to_state <= 0)
                        {
                            if (taski.floor <= current_floor)
                            {
                                if (mindist_down > -taski.floor + current_floor)
                                {
                                    mindist_down = -taski.floor + current_floor;
                                    best_task_down = taski;
                                }
                            }
                        }
                    }
                    if (mindist_down < 100) { return best_task_down; }
                    //再搜索在本楼层以下并且向上的任务，挑最远的
                    foreach (Task taski in tasks)
                    {
                        if (taski.floor <= current_floor)
                        {
                            if (maxdist_down < -taski.floor + current_floor)
                            {
                                maxdist_down = -taski.floor + current_floor;
                                best_task_down = taski;
                            }
                        }
                    }
                    if (maxdist_down != -1) { return best_task_down; }
                    //没有需要向下走的任务
                    return new Task();//没有向下走的任务时返回非法值
                default:
                    return new Task();
            }

        }

        //电梯移动到floor层，实际调用只移动一层
        void move_to_floor(int floor,Form1 Form1)
        {
            if (id % 2 == 0)
            {
                Form1.label_ele[id][current_floor].BackColor = System.Drawing.SystemColors.ControlLight;
            }
            else
            {
                Form1.label_ele[id][current_floor].BackColor = Form1.default_color;
            }
            current_floor = floor;
            Form1.label_ele[id][current_floor].BackColor = Color.Salmon;
        }

        //电梯运行，计时器调用
        public void run(Form1 Form1)
        {
            int no = Form1.Elevators.IndexOf(this);

            //stop_count>0本周期暂停运行
            if (Form1.stop_count[no] > 0)
            {
                Form1.stop_count[no]--;
                if (Form1.stop_count[no] == 0)
                {
                    Form1.close_door(this);
                    Form1.ele_text_label[id].Text = "电梯" + (id+1).ToString();
                }
                return;
            }
            //任务队列为空，设为等待态
            if (tasks.Count == 0)
            {
                Form1.Timers[id].Stop();
                move_state = 0;
                return;
            }
            //一下执行内调度，逻辑见文档
            Task current_task = best_task();
            if (current_task.to_state == 2)
            {
                move_state *= -1;
                current_task = best_task();
            }
            if (current_task.floor == current_floor)
            {
                //arrive
                if (current_task.to_state == 1)
                {
                    Form1.buttons_up_floor[current_floor].BackgroundImage = global::elevator_zzy.Properties.Resources.upgraytransplant;
                }
                else if (current_task.to_state == -1)
                {
                    Form1.buttons_down_floor[current_floor].BackgroundImage = global::elevator_zzy.Properties.Resources.downgraytransplant;
                }
                tasks.Remove(current_task);
                Form1.open_door(this);
                if (Form1.current_control_ele == id)
                {
                    Form1.buttons_in_ele[current_floor].BackColor = Form1.default_color;
                }
                Form1.pushed_button_in_ele[id][current_floor] = 0;
                Form1.ele_text_label[id].Text = "到达" + current_floor.ToString() + "楼";
            }
            else if(current_task.floor > current_floor)
            {
                move_to_floor(current_floor + 1, Form1);
                move_state = 1;
                Form1.ele_text_label[id].Text = "上行";
            }
            else
            {
                move_to_floor(current_floor - 1, Form1);
                move_state = -1;
                Form1.ele_text_label[id].Text = "下行";
            }
        }
    }

    public class Task
    {
        public int floor;//任务楼层
        public int to_state; //任务状态 0为到达任务 1为上行任务 2为下行任务
        public Task(int floor=21,int to_state=2)
        {
            this.floor = floor;
            this.to_state = to_state;
        }
    }
}

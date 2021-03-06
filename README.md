# OS-Elevator-Dispatching
# 同济大学软件学院19级OS课程设计
# 进程管理 - 电梯调度_设计方案报告

| 学号     | 6666   |
| -------- | ------ |
| 姓名     | 7777   |
| 指导老师 | 8888 |

## 目录

[TOC]

## 项目需求

 **本项目设计的是一个电梯调度系统。**

在本项目实现的电梯调度系统中：共有5部电梯，楼层总共高度为20层，每层楼设有一个“向上”按钮和一个“向下”按钮。每一部电梯内设置有各楼层的数字键按钮，和报警键与响铃键。

 电梯调度算法支持多电梯独立运行，联合调度。对于每一个单独电梯采用改进的LOOK算法进行调度，对于外部楼层按钮产生的请求，通过外调度算法将任务根据算法计算分配给一个电梯，从而在当前时间下使得在最短的时间内响应楼层请求并不会出现饥饿现象。



## 开发环境

- **开发软件:** Visual Studio 2017

- **开发语言：**C#

  

## 操作说明

- 打开exe可执行文件,初始界面如下

  ![](https://github.com/Zhaobaba918/OS-Elevator-Dispatching/blob/main/img/%E5%88%9D%E5%A7%8B%E7%95%8C%E9%9D%A2.jpg)

  - 最左侧是电梯内按钮，包括开关门，1-20楼层按钮，响铃，报警。需要说明的是，为了避免冗余，使UI界面尽可能简介，并未将五个电梯的按钮全部罗列，用户首先需要通过左上角的电梯选择按钮选择当前控制的电梯，才能对某个具体的电梯进行操作。若为选择电梯就进行操作，系统会给出一下提示。

  ![](https://github.com/Zhaobaba918/OS-Elevator-Dispatching/blob/main/img/%E6%B8%A9%E9%A6%A8%E6%8F%90%E7%A4%BA.jpg)

  - 右侧是1-20楼的楼层上下按钮，需要注意的是1楼（底楼）没有下按钮，20楼（顶楼）没有下按钮。

  - 最右侧的五列分别代表电梯1-5的运行空间以及电梯，上方的文本在电梯静止时显示电梯号，电梯运动时显示电梯的运动状态。电梯在关门时为红色，开门时为绿色。

- 点击每部电梯的**功能键**(*开/关键*, *报警*, *响铃*,*楼层按钮*), 进行**单部电梯内命令处理**模拟

  - 进行模拟前，首先在左上角选择想要控制的电梯，选择后下方部分将显示相应电梯内的按钮及按钮状态（是否被按下）
  - 电梯内部按钮被按下后，在没有被响应前（电梯没有到达该层）为绿色，电梯到达该层并开门后按钮绿色消除。
  - 右方的电梯状态图直观地显示当前电梯的运动状态及所处楼层

  ![](https://github.com/Zhaobaba918/OS-Elevator-Dispatching/blob/main/img/%E5%86%85%E8%B0%83%E5%BA%A6%E6%A8%A1%E6%8B%9F.jpg)

- **点击各楼层的上/下按钮**, 根据相应的外部调度算法进行**多部电梯外命令处理**模拟

  - 各楼层的上下按钮被按下后，在没有被响应前（没有电梯来服务）为绿色，电梯相应该任务后按钮绿色消除。需要注意的是，电梯到达该层时，不一定会响应该层的服务，会根据相应的内调度算法决定是否相应该层的服务。
  - 右方的电梯状态图直观地显示当前所有电梯的运动状态及所处楼层。

  ![](https://github.com/Zhaobaba918/OS-Elevator-Dispatching/blob/main/img/%E5%A4%96%E8%B0%83%E5%BA%A6.jpg)


## 系统设计

### 电梯参数设置

| 变量          | 类型       | 含义                                     |
| ------------- | ---------- | ---------------------------------------- |
| id            | int        | 电梯编号                                 |
| current_floor | int        | 电梯所在楼层                             |
| move_state    | int        | 电梯运动状态：1为上行，0为等待，-1为下行 |
| tasks         | List<Task> | 电梯的任务队列                           |

### 任务参数设置（PCB）

| 变量     | 类型 | 含义                                               |
| -------- | ---- | -------------------------------------------------- |
| floor    | int  | 任务所在楼层                                       |
| to_state | int  | 任务的去向：1为上行任务，0为到达任务，-1为下行任务 |

### 电梯状态转化

<img src="img\电梯状态转换.png" style="zoom:50%;" />

需要注意的是，这里的**等待态与电梯停止并不等价**，等待态只有在电梯的任务队列为空时才会出现，所以电梯的上行与下行之间可以直接转换



## 算法设置

### 单部电梯内任务处理——内调度（改进的LOOK算法）

**单部电梯内任务**：指某个电梯的任务队列中的任务，其来源有以下两种

- 电梯内按钮被按下，向该电梯的任务队列中加入一个到达任务（to_state=0），任务的楼层为触发按钮对应的楼层
- 某楼层的上/下键被按动，生成一个上行或下行任务（to_state=0或1），并且该任务通过外调度（下文有详细介绍）被分配给当前电梯

**调度逻辑如下**

- **当前电梯处于等待态**（此时刻前电梯的任务队列为空）

  - 从任务队列中选取一个离电梯所在楼层最近的任务执行

- **当前电梯处于上行状态**

  - 如果电梯所在楼层或以上有上行任务或到达任务，选取一个离电梯所在楼层最近的上行任务或到达任务执行
  - 否则，如果电梯所在楼层或以上有下行任务，选取一个离电梯所在楼层最远的下行任务执行
  - 否则，改变电梯状态为下行，按照下行状态的任务选取逻辑选取一个任务执行，若不能挑选出一个任务，则说明任务队列为空，将电梯状态改为等待态

  **当前电梯处于下行状态**

  - 如果电梯所在楼层或以下有下行任务或到达任务，选取一个离电梯所在楼层最近的下行任务或到达任务执行
  - 否则，如果电梯所在楼层或以下有上行任务，选取一个离电梯所在楼层最远的上行任务执行
  - 否则，改变电梯状态为上行，按照上行状态的任务选取逻辑选取一个任务执行，若不能挑选出一个任务，则说明任务队列为空，将电梯状态改为等待态

  **执行任务**：若任务楼层大于当前楼层，上行一层；若任务楼层小于当前楼层，下行一层；若任务楼层等于当前楼层，开门，并将任务从任务队列中删去。

  **内调度触发条件**：电梯行走一层，或有新的任务加入当前电梯的任务队列

### 多部电梯间任务处理——外调度

​	**外调度触发条件**：1-20楼的某个上下键被按动，产生一个上行任务或下行任务，需要将该任务分	配给一个电梯

​	**调度逻辑如下：**

- 计算每个电梯相应当前任务的代价（所需时间），计算逻辑如下（以上行任务为例）：
  - 若任务楼层 $\ge$ 电梯当前所在楼层 且 电梯状态为上行，代价 = $任务楼层 - 电梯当前所在楼层 + 5 \times停靠数 $
  - 若任务楼层 $<$ 电梯当前所在楼层 且 电梯状态为上行，代价 = $40 - 任务楼层 - 电梯当前所在楼层 + 5 \times停靠数$
  - 若电梯状态为下行，代价 = $任务楼层 + 电梯当前所在楼层 + 5 \times停靠数 $
  - 若电梯状态为等待态，代价 = $|任务楼层 - 电梯当前所在楼层 |+ 5 \times停靠数$
- 将当前任务分配给代价最小的电梯（加入该电梯的任务队列）

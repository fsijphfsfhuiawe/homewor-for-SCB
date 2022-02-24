//【问题描述】
//　　给定n个数，请找出其中相差（差的绝对值）最小的两个数，输出它们的差值的绝对值。
//【输入形式】
//　　输入第一行包含一个整数n。
//　　第二行包含n个正整数，相邻整数之间使用一个空格分隔。
//【输出形式】
//　　输出一个整数，表示答案。
//【样例输入】
//5
//1 5 4 8 20
//【样例输出】
//1
//【评分标准】
//　对于所有评测用例，2 ≤ n ≤ 1000，每个给定的整数都是不超过10000的正整数。

#include<iostream>
#include<cmath>
using namespace std;

int main0() {
	cout << "please enter the numbers of your input." << endl;
	int a[10000] = { 0 };
	int n;
	cout << "enter the numbers." << endl;
	cin >> n;
	int m = 10000;
	for (int i = 0; i < n; i++) {
		cin >> a[i];
	}
	for (int i = 0; i <= n; i++) {
		for (int j = i + 1; j <= n; j++) {
			if (abs(a[i] - a[j]) < m)
				m = abs(a[i] - a[j]);
		}
	}
	cout << m;
	return 0;
}
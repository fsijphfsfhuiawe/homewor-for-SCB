//������������
//��������n���������ҳ���������ľ���ֵ����С����������������ǵĲ�ֵ�ľ���ֵ��
//��������ʽ��
//���������һ�а���һ������n��
//�����ڶ��а���n������������������֮��ʹ��һ���ո�ָ���
//�������ʽ��
//�������һ����������ʾ�𰸡�
//���������롿
//5
//1 5 4 8 20
//�����������
//1
//�����ֱ�׼��
//��������������������2 �� n �� 1000��ÿ���������������ǲ�����10000����������

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
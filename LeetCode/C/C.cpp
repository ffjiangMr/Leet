// C.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

#include "LeetCode.h"

using namespace std;
#define PI 3.141592;

int fun(char* a, char* b)
{
	while ((*a != '\0') && (*b != '\0') && (*a == *b))
	{
		a++;
		b++;
	}
	return (*a - *b);
}

int main()
{	
	float asd = PI;
	auto leet = new LeetCode();
	vector<vector<int>> temp_;
	temp_.push_back(vector<int>{1, 2});
	temp_.push_back(vector<int>{3, 4});
	auto projectionArea = leet->projectionArea(temp_);
	auto binaryGap = leet->binaryGap(INT32_MAX);
	auto lengthLongestPath = leet->lengthLongestPath("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext");
	auto shortestToChar = leet->shortestToChar("loveleetcode", 'e');
	auto lexicalOrder = leet->lexicalOrder(1234);
	TreeNode *root = new TreeNode(1);
	TreeNode *node4 = new TreeNode(2);
	TreeNode *node6 = new TreeNode(2);
	TreeNode* node3_ = new TreeNode(3);
	TreeNode* node7_ = new TreeNode(4);
	node4->left = node3_;
	node4->right = node7_;
	root->left = node4;
	root->right = node6;
	TreeNode *node3 = new TreeNode(3);
	TreeNode *node7 = new TreeNode(4);
	node6->left = node3;
	node6->right = node7;
	vector<int> para = { 9,9,9,9,9 };
    auto result = leet->isSymmetric(root);
	int temp = cin.get();
}





// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file

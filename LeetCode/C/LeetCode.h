#pragma once
#include <vector>
#include <math.h>
#include <unordered_set>
#include <map>
#include <unordered_map>
#include <algorithm>
#include <queue>
#include <numeric>
#include <stack>
#include <string>
#include <iostream>
#include <time.h>

#include "Header.h"

using namespace std;

class LeetCode
{
public:
	int projectionArea(vector<vector<int>>& grid);
	int binaryGap(int n);
	int lengthLongestPath(string input);
	vector<int> shortestToChar(string s, char c);
	vector<int> lexicalOrder(int n);
	void CalLexical(const int num, const int& max_num, vector<int>& result);

	bool isSymmetric(TreeNode* root);
	bool isSymmetricHelper(TreeNode* root_a, TreeNode* root_b);
	bool isValidBST(TreeNode* root);
	bool isValidBSTHelper(TreeNode* root, long long int min_val, long long int max_val);
	//NestedInteger deserialize(string s);
	int maximumWealth(vector<vector<int>>& accounts);
	int removeDuplicates(vector<int>& nums);

public:
	void moveZeroes(vector<int>& nums);
	int maxProfit(vector<int>& prices);
	bool containsDuplicate(vector<int>& nums);
	int singleNumber(vector<int>& nums);
	vector<int> intersect(vector<int>& nums1, vector<int>& nums2);
	vector<int> plusOne(vector<int>& digits);
	bool findTarget(TreeNode* root, int k);
};


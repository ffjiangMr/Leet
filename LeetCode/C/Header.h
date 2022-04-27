#pragma once
#include<vector>

// class NestedInteger {
//public:
//NestedInteger();
//NestedInteger(int value);
//bool isInteger() const;
//int getInteger() const;
//void setInteger(int value);
//void add(const NestedInteger& ni);
//const vector<NestedInteger>& getList() const;
//};


 typedef double (*callback)(double);

 struct TreeNode {
     int val;
     TreeNode* left;
     TreeNode* right;
     TreeNode() : val(0), left(nullptr), right(nullptr) {}
     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
     TreeNode(int x, TreeNode* left, TreeNode* right) : val(x), left(left), right(right) {}
 };
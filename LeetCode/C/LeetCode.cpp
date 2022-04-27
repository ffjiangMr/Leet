#include "LeetCode.h"

int LeetCode::projectionArea(vector<vector<int>>& grid)
{
	int result = 0;
	int xz = 0;
	int yz = 0;
	int xy = 0;
	for (int x = 0; x < grid.size(); x++)
	{
		xz = 0;
		yz = 0;
		xy = 0;
		for (int y = 0; y < grid[x].size(); y++)
		{
			xy += grid[x][y] > 0 ? 1 : 0;
			xz = max(xz, grid[x][y]);
			yz = max(yz, grid[y][x]);
		}
		result += xz;
		result += xy;
		result += yz;
	}
	return result;
}

class Solution {
private:
	unordered_map<int, vector<int>> table;
public:
	Solution(vector<int>& nums)
	{
		for (int index = 0; index < nums.size(); index++)
		{
			table[nums[index]].emplace_back(index);
		}
		srand(time(nullptr));
	}

	int pick(int target)
	{
		auto list = this->table[target];
		return list[rand() % list.size()];
	}
};

int LeetCode::binaryGap(int n) {
	int result = 0;
	int flag = 31;
	int index = 0;
	bool isBeg = false;
	while (flag > 0)
	{
		flag--;
		auto temp = n & 1;
		index = isBeg == true ? index + 1 : 0;
		if (temp == 1)
		{
			isBeg = true;
			result = result < index ? index : result;
			index = 0;
		}
		n = n >> 1;
	}

	return result;
}

int LeetCode::lengthLongestPath(string input)
{
	int result = 0;
	char* buf;
	auto item = strtok_s(const_cast<char*>(input.c_str()), "\n", &buf);
	int deep = 0;
	int current = 0;
	vector<int> indexs;
	string path;
	while (item != nullptr)
	{
		current = 0;
		while (item[0] == '\t')
		{
			current++;
			item++;
		}
		if (current <= deep)
		{
			while ((deep >= current) && (indexs.size() > 0))
			{
				path = path.substr(0, indexs[indexs.size() - 1]);
				indexs.pop_back();
				deep--;
			}
		}
		if (current >= deep)
		{
			indexs.emplace_back(path.length());
			if (current != 0)
			{
				path += "/" + string(item);
			}
			else
			{
				path = string(item);
			}
		}
		for (auto c : string(item))
		{
			if (c == '.')
			{
				result = max(result, (int)path.length());
				break;
			}
		}
		deep = current;
		item = strtok_s(nullptr, "\n", &buf);
	}
	return result;
}

vector<int> LeetCode::shortestToChar(string s, char c)
{
	vector<int> result;
	vector<int> table;
	for (int index = 0; index < s.length(); index++)
	{
		if (s[index] == c)
		{
			table.emplace_back(index);
		}
	}
	if (table.size() > 0)
	{
		int flag = 0;
		int before = table[flag];
		int end = table[flag];
		for (int index = 0; index < s.length(); index++)
		{
			int temp = min(abs(index - before), abs(index - end));
			result.emplace_back(temp);
			if ((temp == 0) && ((++flag) < table.size()))
			{
				before = end;
				end = table[flag];
			}
		}
	}
	return result;
}

vector<int> LeetCode::lexicalOrder(int n)
{
	vector<int> result;
	for (int flag = 1; flag < min(10, n); flag++)
	{
		CalLexical(flag, n, result);
	}
	return result;
}

void LeetCode::CalLexical(const int num, const int& max_num, vector<int>& result)
{
	result.push_back(num);
	cout << num << ",";
	if (num * 10 <= max_num)
	{
		CalLexical(num * 10, max_num, result);
	}
	if ((num > 9) && ((num + 1) <= max_num) && (((num + 1) / 10) == (num / 10)))
	{
		CalLexical(num + 1, max_num, result);
	}
}

bool LeetCode::isSymmetric(TreeNode* root)
{
	return this->isSymmetricHelper(root->left, root->right);
}
bool LeetCode::isSymmetricHelper(TreeNode* root_a, TreeNode* root_b)
{
	bool result = true;
	if ((root_a != nullptr) && (root_b != nullptr))
	{
		result &= root_a->val == root_b->val;
		result &= this->isSymmetricHelper(root_a->left, root_b->right);
		result &= this->isSymmetricHelper(root_a->right, root_b->left);
	}
	else if ((root_a == nullptr) && (root_b == nullptr))
	{
		// nothing
	}
	else
	{
		result = false;
	}
	return result;
}

bool LeetCode::isValidBST(TreeNode* root)
{
	return this->isValidBSTHelper(root, INT64_MIN, INT64_MAX);
}

bool LeetCode::isValidBSTHelper(TreeNode* root, long long int min_val, long long int max_val)
{
	bool result = true;
	if (root != nullptr)
	{
		result &= root->val < max_val;
		result &= root->val > min_val;
		if (root->left != nullptr)
		{
			result &= isValidBSTHelper(root->left, min_val, root->val);
		}
		if (root->right != nullptr)
		{
			result &= isValidBSTHelper(root->right, root->val, max_val);
		}
	}
	return result;
}

//NestedInteger LeetCode::deserialize(string s)
//{
//	stack<NestedInteger> buf;
//	int num = 0;
//	bool isNeg = false;
//	if (s[0] != '[')
//	{
//		return NestedInteger(stoi(s));
//	}
//	for (int index = 0; index < s.size(); index++)
//	{
//		if (s[index] == '[')
//		{
//			buf.emplace(NestedInteger());
//		}
//		else if ((s[index] == '[') || ((s[index] == ',')))
//		{
//			if (isNeg == true)
//			{
//				num *= -1;
//			}
//			buf.top().add(NestedInteger(num));
//			num = 0;
//			isNeg = false;
//			if ((s[index] == ']') && (buf.size() > 0))
//			{
//				auto top = buf.top();
//				buf.pop();
//				buf.top().add(top);
//			}
//		}
//		else if(s[index] == '-')
//		{
//			isNeg = true;
//		}
//		else
//		{
//			num = num * 10 + (s[index] - '0');
//		}
//	}
//	return buf.top();
//}

int LeetCode::maximumWealth(vector<vector<int>>& accounts)
{
	int max_account = 0;
	for (auto& user : accounts)
	{
		max_account = max(max_account, accumulate(user.begin(), user.end(), 0));
	}
	return max_account;
}

bool LeetCode::findTarget(TreeNode* root, int k)
{
	bool result = false;
	unordered_set<int> table;
	queue<TreeNode*> queue;
	queue.push(root);
	while (queue.empty() != false)
	{
		auto tree = queue.front();
		queue.pop();
		if (table.count(k - tree->val) > 0)
		{
			result = true;
			break;
		}
		else
		{
			table.insert(tree->val);
		}
		if (tree->right != nullptr)
		{
			queue.push(tree->right);
		}
		if (tree->left != nullptr)
		{
			queue.push(tree->left);
		}
	}
	return result;
}

void LeetCode::moveZeroes(vector<int>& nums)
{
	int fast = 0, slow = 0;
	while (slow < nums.size())
	{
		while ((fast < nums.size()) && (nums[fast] == 0))
		{
			fast++;
		}
		if (fast < nums.size())
		{
			nums[slow++] = nums[fast++];
		}
		else
		{
			nums[slow++] = 0;
		}
	}
}

vector<int> LeetCode::plusOne(vector<int>& digits)
{
	int carry = 1;
	vector<int>::reverse_iterator begin = digits.rbegin();
	for (; begin != digits.rend(); begin++)
	{
		auto temp = carry + (*begin);
		(*begin) = temp % 10;
		carry = temp / 10;
	}
	vector<int> result(carry == 1 ? digits.size() + 1 : digits.size());
	result[0] = 1;
	auto point = carry == 1 ? ++result.begin() : result.begin();
	copy(digits.begin(), digits.end(), point);
	return result;
}

int LeetCode::removeDuplicates(vector<int>& nums)
{
	int index = 0, flag = 1;
	while (flag < nums.size())
	{
		if (nums[index] != nums[flag])
		{
			nums[++index] = nums[flag];
		}
		flag++;
	}
	return index + 1;
}

int LeetCode::maxProfit(vector<int>& prices)
{
	const int length = prices.size();
	int** dp = new int* [length];
	dp[0] = new int[2];
	dp[0][0] = 0;
	dp[0][1] = -prices[0];
	for (int index = 1; index < length; index++)
	{
		dp[index] = new int[2];
		dp[index][0] = max(dp[index - 1][0], dp[index - 1][1] + prices[index]);
		dp[index][1] = max(dp[index - 1][1], dp[index - 1][0] - prices[index]);
	}
	return dp[length - 1][0];
}


bool LeetCode::containsDuplicate(vector<int>& nums)
{
	bool result = false;
	unordered_set<int> set;
	for (auto item : nums)
	{
		if (set.insert(item).second == false)
		{
			result = true;
			break;
		}
	}

	return result;
}

int LeetCode::singleNumber(vector<int>& nums)
{
	int result = 0;
	for (auto item : nums)
	{
		result ^= item;
	}
	return result;
}

vector<int> LeetCode::intersect(vector<int>& nums1, vector<int>& nums2)
{
	vector<int> result;
	map<int, int> table;
	for (auto item : nums1)
	{
		if (table.find(item) == table.end())
		{
			table[item] = 0;
		}
		table[item]++;
	}
	for (auto item : nums2)
	{
		if (table.find(item) != table.end())
		{
			result.push_back(item);
			if ((--table[item]) == 0)
			{
				table.erase(item);
			}
		}
	}
	return result;
}
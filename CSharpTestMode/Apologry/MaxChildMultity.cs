/*
 * 最大子列和问题，求出给定区间内，最大子列的和和区间。
 */

using System;

public class MaxChildMultity {
    public int[] data = new[] {
        1, -2, 4, -3, 4, -5, -3, 2
    }; // 原始数据

    public void Run() {
        CalculateByQiongJu();
        CalculateByQiongJuOptimate();
        PrintResult(CalculateByDivideAndConquer(0,data.Length - 1));
    }

    /// <summary>
    /// 穷举法求解 复杂度 O(N^3)
    /// </summary>
    public void CalculateByQiongJu() {
        int i, j, k;
        int thisSum, maxSum = 0;
        var len = data.Length;
        for (i = 0; i < len; i++) {
            for (j = 0; j < len; j++) {
                thisSum = 0;
                for (k = i; k <= j; k++) {
                    thisSum += data[k];
                }

                if (thisSum > maxSum) {
                    maxSum = thisSum;
                }
            }
        }
        PrintResult(maxSum);
    }

    /// <summary>
    /// 优化穷举法求解 复杂度 O(N^2)
    /// </summary>
    public void CalculateByQiongJuOptimate() {
        int i, j, k;
        int thisSum, maxSum = 0;
        var len = data.Length;
        for (i = 0; i < len; i++) {
            thisSum = 0; // 对于相同的 i，不同的 j，只需要在上一个基础上加即可
            for (j = i; j < len; j++) {
                thisSum += data[j];

                if (thisSum > maxSum) {
                    maxSum = thisSum;
                }
            }
        }
        PrintResult(maxSum);
    }

    /// <summary>
    /// 使用分治法求解 复杂度 O(N(log(N))
    /// </summary>
    public int CalculateByDivideAndConquer(int left, int right) {
        if (left == right) { // 递归停止条件
            return data[left] > 0? data[left] : 0;
        }
        // 开始分
        int center = (left + right) / 2;
        int maxLeftSum = CalculateByDivideAndConquer(left, center);
        int maxRightSum = CalculateByDivideAndConquer(center + 1, right);
        
        //求跨分界线的最大子列和（ = 以中心点往左的最大子列和 + 以中心点往右的最大子列和）
        int maxLeftBorderSum = 0;
        int leftBorderSum = 0;
        for (int i = center - 1; i >= left; i--) { // 中心点往左扫描
            leftBorderSum += data[i];
            if (leftBorderSum > maxLeftBorderSum) {
                maxLeftBorderSum = leftBorderSum;
            }
        }

        int maxRightBorderSum = 0;
        int rightBorderSum = 0;
        for (int i = center; i <= right; i++) { // 中心点往右扫描
            rightBorderSum += data[i];
            if (rightBorderSum > maxRightBorderSum) {
                maxRightBorderSum = rightBorderSum;
            }
        }

        int maxCenterBorderSum = maxLeftBorderSum + maxRightBorderSum;

        return maxLeftSum > maxRightSum? maxLeftSum > maxCenterBorderSum? maxLeftSum : maxCenterBorderSum : maxRightSum > maxCenterBorderSum? maxRightSum : maxCenterBorderSum;
    }

    /// <summary>
    /// 动态规划求解
    /// </summary>
    /// <returns></returns>
    public void CalculateByDP() {
        var len = data.Length;
        var dp = new int[len];
        var maxSum = data[0];
        for (int i = 1; i < len; i++) {
            if (data[i - 1] > 0) {
                dp[i] = data[i] + data[i - 1];
            } else {
                dp[i] = data[i];
            }

            if (dp[i] > maxSum) {
                maxSum = dp[i];
            }
        }
        PrintResult(maxSum);
    }


    private void PrintResult(int maxSum) {
        Console.WriteLine($"MaxSum is {maxSum}");
    }
}
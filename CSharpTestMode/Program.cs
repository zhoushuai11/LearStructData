using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTestMode {
    internal class Program {
        static void Main() {
            // LeetCodeProgram leetCodeProgram = new LeetCodeProgram();
            // leetCodeProgram.Start();
            var t = new Table();
            t.Create();
        }
        
        public static string LongestCommonPrefix(string[] strs) {
            var str = "";
            var targetStr = strs[0];
            var targetLen = targetStr.Length;
            var len = strs.Length;
            var count = 0;
            for(int i = 1;i < len;i ++){
                var nowStr = strs[i];
                var nowStrLen = nowStr.Length;
                var ct = 0;
                var forValue = nowStrLen > targetLen ? targetLen : nowStrLen;
                for(int j = 0;j < forValue;j ++){
                    if((j > nowStrLen - 1 || j > targetLen - 1) || nowStr[j] != targetStr[j]){
                        break;
                    }
                    ct ++;
                }
                if(count > ct || i == 1){
                    count = ct;
                }
            }
            str = targetStr.Substring(0,count);
            return str;
        
        }

        public static int MaxSubArray(int[] nums) {
            var len = nums.Length;
            if (len == 1) {
                return nums[0];
            }

            var value = 0;
            var max = nums[0];
            for (int i = 0; i < len; i++) {
                var nowVal = nums[i];
                if (value < 0) {
                    value = 0;
                }

                var nowTarget = value + nowVal;
                if (nowTarget < 0) {
                    value = nowVal;
                } else {
                    value = nowTarget;
                }

                if (value > max) {
                    max = value;
                }
            }

            return max;
        }

        /// <summary>
        /// 一分为二，取左边最大，取右边最大，取中间最大，然后合并
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MaxSubArrayByFenZhi(int[] nums) {
            var len = nums.Length;
            if (len == 1) {
                return nums[0];
            }

            var max = 0;

            return max;
        }

        static int GetMaxSum(int[] nums,int from,int to) {
            var value = 0;
            var now = 0;
            var max = 0;
            if (from == to) {
                max = nums[from];
            } else {
                while (from < to) {
                    if (value + from < 0) {
                        
                    } else {
                        value = value + from;
                    }

                    if (max < value) {
                        max = value;
                    }
                    from++;
                }
            }
            return max;
        }

        public static int Reverse(int x) {
            var num = x;
            var lessNum = 0;
            var target = 0;
            while (num != 0) {
                if (target < Int32.MinValue / 10 || target > Int32.MaxValue / 10) {
                    return 0;
                }
                lessNum = num % 10;
                num = num / 10;
                target = target * 10 + lessNum;
            }
            return target;
        }
        
        public static ListNode ReverseList(ListNode head) {
            ListNode nowNode = head;
            var nextNode = head.next;
            while(nextNode != null){
                var newNextNode = nextNode.next;
                nextNode.next = nowNode;
                nowNode = nextNode;
                nextNode = newNextNode;
            }
            return nowNode;
        }

        public static void DebugListNode(ListNode node) {
            var value = node;
            while (value != null) {
                Console.WriteLine(value.val);
                value = value.next;
            }
        }

        // public static int Trap(int[] height) {
        //     var len = height.Length;
        //     var max = 0;
        //     var value = 0;
        //     var isCanGet = false;
        //     var last = height[0];
        //     var now = 0;
        //     
        //     var leftMaxHeight = 0;
        //     var nowHeight = 0;
        //     for (int i = 1; i < len; i++) {
        //         now = height[i];
        //         if (now > last) {
        //             
        //         } else if (now < last) {
        //             
        //         }
        //
        //         if (now < leftMaxHeight) {
        //             value += leftMaxHeight - 
        //         }
        //     }
        //
        //     return value;
        // }
        
        public static int MySqrt(int x) {
            var max = x;
            var min = 0;
            // 二分查找搜索目标
            while (max - min > 1) {
                var value = (max + min) / 2;
                if (value * value > x) {
                    max = value;
                } else {
                    min = value;
                }
            }
            return min;
        }
    }
}

public struct TestStruct {
    public TestStruct(int setM, test setValue) {
        m = setM;
        value = setValue;
    }
    public int m;
    public test value;
}

public class test {
    private int m = 3;
}

public class ListNode {
    public int val;
    public ListNode next;

    public ListNode(int val, ListNode next) {
        this.val = val;
        this.next = next;
    }
}

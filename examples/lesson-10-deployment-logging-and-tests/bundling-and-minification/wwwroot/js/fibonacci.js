// https://medium.com/developers-writing/fibonacci-sequence-algorithm-in-javascript-b253dc7e320e

function memo(num, memo) {
  memo = memo || {};

  if (memo[num]) return memo[num];
  if (num <= 1) return 1;

  return memo[num] = memo(num - 1, memo) + memo(num - 2, memo);
}

function loop(num){
  var a = 1, b = 0, temp;

  while (num >= 0){
    temp = a;
    a = a + b;
    b = temp;
    num--;
  }

  return b;
}

function recursion(num) {
  if (num <= 1) return 1;

  return recursion(num - 1) + recursion(num - 2);
}
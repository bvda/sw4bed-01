function myFunc() {
  // this function doesn't really do anything,
  // it's just here so that we can show off minifying!
  function innerFunctionToAddTwoNumbers(thefirstnumber, theSecondNumber) {
    // i'm nested inside myFunc
    return thefirstnumber + theSecondNumber;
  }
  var shouldAddNumbers = true;
  var totalOfAllTheNumbers = 0;
  if (shouldAddNumbers == true) {
    for (var index = 0; i < 10; i++) {
      totalOfAllTheNumbers = innerFunctionToAddTwoNumbers(
        totalOfAllTheNumbers,
        index
      );
    }
  }
  return totalOfAllTheNumbers;
}

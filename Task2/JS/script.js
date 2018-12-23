var currentTab = 0;
showTab(currentTab);

function showTab(n) {
  // This function will display the specified tab of the form...
  var x = document.getElementsByClassName("tab");
  x[n].style.display = "block";
  //если первый шаг, то не выводить кнопку назад
  if (n == 0) {
    document.getElementById("prevBtn").style.display = "none";
  } else {
    document.getElementById("prevBtn").style.display = "inline";
  }
  //если полседний шаг, то не выводить кнопку вперед
  if (n == (x.length - 1)) {
	//вывести все полученные данные
	writeInfo();
    document.getElementById("nextBtn").style.display = "none";
  }
  //мы в середине
  else {
	document.getElementById("nextBtn").style.display = "inline";
    document.getElementById("nextBtn").innerHTML = "Далее";
  }
  //отобразить пользователю шаг, на котором находится на текущий момент пользователь
  fixStepIndicator(n)
}

function nextPrev(n) 
{
  var x = document.getElementsByClassName("tab");
  if (n == 1 && !validateForm()) return false;
  x[currentTab].style.display = "none";
  // сделать переход назад или вперед
  currentTab = currentTab + n;
  // мы в конце
  if (currentTab >= x.length) {
    return false;
  }
  showTab(currentTab);
}

function validateForm() {
  // Провери, что на текущм шаге значения заполнены
  var x, y, i, valid = true;
  x = document.getElementsByClassName("tab");
  y = x[currentTab].getElementsByTagName("input");
  for (i = 0; i < y.length; i++) {
    // поля не должны быть пустыми
    if (y[i].value == "") {
      y[i].className += " invalid";
      valid = false;
    }
  }
  // Если все заполено, то можно будет перейти к следующей форме
  if (valid) {
    document.getElementsByClassName("step")[currentTab].className += " finish";
  }
  return valid;
}

function fixStepIndicator(n) {
  var i, x = document.getElementsByClassName("step");
  for (i = 0; i < x.length; i++) {
    x[i].className = x[i].className.replace(" active", "");
  }
  x[n].className += " active";
}

function writeInfo()
{
	var x = document.getElementById("fname").value;
	document.getElementById("o_fname").innerHTML = "Имя: " + x;
	
	x = document.getElementById("lname").value;
	document.getElementById("o_lname").innerHTML = "Фамилия: " +x;
	
	x = document.getElementById("mname").value;
	document.getElementById("o_mname").innerHTML = "Отчество: " +x;
	
	x = document.getElementById("birthday").value;
	document.getElementById("o_birthday").innerHTML = "Дата рождения: " + x;
	
	x = document.getElementById("ismale");
	if(x.checked)
		document.getElementById("o_sex").innerHTML = "Пол мужской";
	else
		document.getElementById("o_sex").innerHTML = "Пол женский";
	
	x = document.getElementById("pserial").value;
	document.getElementById("o_pserial").innerHTML = "Серия: " + x;
	
	x = document.getElementById("pnumber").value;
	document.getElementById("o_pnumber").innerHTML = "Номер: " + x;
	
	x = document.getElementById("pdate").value;
	document.getElementById("o_pdate").innerHTML = "Дата выдачи: " + x;
	
	x = document.getElementById("pplace").value;
	document.getElementById("o_pplace").innerHTML = "Место выдачи: " + x;
	
	x = document.getElementById("education").value;
	document.getElementById("o_education").innerHTML = "Образование: " + x;
	
	x = document.getElementById("state").value;
	document.getElementById("o_state").innerHTML = "Статус: " + x;
	
    var hobbies = "";
	if(document.getElementById("hread").checked)
		hobbies += document.getElementById("hread").value + ";";
	if(document.getElementById("hsleep").checked)
		hobbies += document.getElementById("hsleep").value + ";";
	if(document.getElementById("heat").checked)
		hobbies += document.getElementById("heat").value + ";";
	if(document.getElementById("hplay").checked)
		hobbies += document.getElementById("hplay").value + ";";
	if(!hobbies.length)
		document.getElementById("o_hobbies").innerHTML = "Список увлечений: " +"Не увлекаетесь";
	else
		document.getElementById("o_hobbies").innerHTML = "Список увлечений: " + hobbies;
	
}
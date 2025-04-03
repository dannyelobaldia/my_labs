// Copyright Dannyel Obaldia Universidad de Costa Rica 2025

function agregar() {
  const list = document.getElementById("lista");
  const items = list.getElementsByTagName("li").length;
  const newElement = document.createElement("li");
  newElement.textContent = 'Elemento' + (items + 1);
  list.appendChild(newElement);
}

function cambiarFondo() {
  if(document.body.style.backgroundColor === "white") {
    document.body.style.backgroundColor = "lightblue";
  } else {
    document.body.style.backgroundColor = "white";
  }
}

function borrar() {
  const list = document.getElementById("lista");
  if(list.getElementsByTagName("li").length > 0) {
    list.removeChild(list.lastElementChild);
  }
}
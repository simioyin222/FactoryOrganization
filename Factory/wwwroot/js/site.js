// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', () => {
  const themeSwitcher = document.getElementById('theme-switcher');

  //  saved theme preference
  const currentTheme = localStorage.getItem('theme');
  if (currentTheme === 'dark') {
    document.body.classList.add('dark-mode');
  }

  themeSwitcher.addEventListener('click', () => {
    document.body.classList.toggle('dark-mode');
    let theme = 'light';
    if (document.body.classList.contains('dark-mode')) {
      theme = 'dark';
    }
    // theme change to locality 
    localStorage.setItem('theme', theme);
  });
});

document.addEventListener('DOMContentLoaded', () => {
  // Example dynamic addition function
  function addEngineerOrMachine(name, type) {
    const taskElement = document.createElement('div');
    taskElement.classList.add('task');
    if (type === 'new') {
      taskElement.classList.add('new-item'); // Class for new items
    }
    taskElement.textContent = name;
    document.querySelector('.kanban-column.todo .tasks').appendChild(taskElement);
  }

  // Example function to move items to "In Progress"
  function moveToInProgress(name) {
    const items = document.querySelectorAll('.kanban-column.todo .task');
    items.forEach(item => {
      if (item.textContent === name) {
        document.querySelector('.kanban-column.in-progress .tasks').appendChild(item);
        item.classList.remove('new-item'); // Optional: remove the new item highlight
      }
    });
  }

  // Simulate adding engineers 
  addEngineerOrMachine('Billy(Engineer)', 'new');
  addEngineerOrMachine('PS5(Machine)', 'new');

  // Simulate adding details
   moveToInProgress('Billy(Engineer)');
   moveToInProgress('PS5(Machine)');
});
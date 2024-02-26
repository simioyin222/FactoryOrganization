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

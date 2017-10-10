// Write your JavaScript code.
let playerSearch = document.querySelector('.searchPlayerFn')
let playerForm = document.querySelector('form')
let input = document.querySelector('input')
let search = input.value
let url = "/proxy"



playerSearch.addEventListener('submit', event =>{
    let playerInfo = fetch(url).then(response => response.json())
    .then(data => {
        console.log(data)
    })
    })
    



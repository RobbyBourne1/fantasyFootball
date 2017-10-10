// Write your JavaScript code.
let playerSearch = document.querySelector('.searchPlayerFn')
let playerForm = document.querySelector('form')
let input = document.querySelector('input')
let search = input.value
let url = "http://anyorigin.com/go?url=https://www.fantasyfootballnerd.com/service/players/json/yftn2uw58qsv/"

let playerInfo = fetch(url).then(response => response.json()).then(data => data.results)


playerSearch.addEventListener('input', event =>{
    console.log(playerInfo)
})



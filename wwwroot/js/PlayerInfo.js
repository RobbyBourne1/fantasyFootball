
let url = "/proxy"

fetch(url).then(response => response.json())
.then(data => {
    console.log(data)
    let playersFound = data.Players.filter(player => {
        return player.displayName.indexOf(_userInput) >= 0;
    })
})
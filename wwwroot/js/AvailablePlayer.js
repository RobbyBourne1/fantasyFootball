let allPlayers = document.querySelector('.allPlayers')
let allPlayerBody = document.querySelector('.allPlayerBody')
let allPlayerSearch = document.querySelector('.searchAllPlayerName')

allPlayerSearch.addEventListener('input', event => {
    const _userInput = event.target.value

let allPlayerInfo = fetch(url).then(response => response.json())
    .then(data => {
        console.log(data)
        let playersFound = data.Players.filter(player => {
            return player.displayName.indexOf(_userInput) >= 0;
        })
            displayOfPlayers.innerHTML = ''
            playersFound.slice(0, 15).forEach(function (playerData, index) {
                
                allPlayerBody.innerHTML += `
                <tr>
                    <td><a asp-area="" asp-controller="PlayerInfo" asp-action="Index">${playerData.displayName}</a></td>
                    <td>${playerData.position}</td>
                    <td>${playerData.team}</td>
                    <td>${playerData.active}</td>
                    <td>${playerData.college}</td>
                </tr>
              `;
            })
    })
})
// Input Players JS
let playerSearch = document.querySelector('.searchPlayerName')
let playerForm = document.querySelector('form')
let input = document.querySelector('input')
let search = input.value
let url = "/proxy"

playerSearch.addEventListener('input', event => {
    const _userInput = event.target.value

    let playerInfo = fetch(url).then(response => response.json())
        .then(data => {
            console.log(data)
            let playersFound = data.Players.filter(player => {
                return player.displayName.indexOf(_userInput) >= 0;
            })
            let displayOfPlayers = document.querySelector('.playerInfo')
            displayOfPlayers.innerHTML = ''
            playersFound.slice(0, 3).forEach(function (playerData, index) {

                if (playerData.active == 0) {
                    allPlayerBody.innerHTML += ""
                } else {
                    allPlayerBody.innerHTML +=`
                      <div class="col-sm-12">
                        <dl class="dl-horizontal col-sm-10">
                            <dt>Player Name</dt>
                            <dd>${playerData.displayName}</dd>
                            <dt>Player Position</dt>
                            <dd>${playerData.position}</dd>
                            <dt>Player Team</dt>
                            <dd>${playerData.team}</dd>
                        </dl>
                        <button type="button" value="Create" class="btn btn-default col-sm-2 add-button" data-displayName="${playerData.displayName}" data-position="${playerData.position}" data-team="${playerData.team}" data-fname="${playerData.fname}" data-lname="${playerData.lname}" data-team="${playerData.team}" data-jersey="${playerData.jersey}" data-active="${playerData.active}" data-college="${playerData.college}" data-dob="${playerData.dob}">Add</button>
                      </div>
                    `;
                }
            }, this);
            document.querySelectorAll(".add-button").forEach(button => {
                button.addEventListener("click", (e) => {
                    console.log(e.target);
                    const data = {
                        displayName : e.target.getAttribute("data-displayName"),
                        position : e.target.getAttribute("data-position"),
                        team : e.target.getAttribute("data-team"),
                        fname : e.target.getAttribute("data-fname"),
                        lname : e.target.getAttribute("data-lname"),
                        jersey : e.target.getAttribute("data-jersey"),
                        active : e.target.getAttribute("data-active"),
                        college : e.target.getAttribute("data-college"),
                        dob : e.target.getAttribute("data-dob"),
                        FantasyTeamModelId : teamSelect.options[teamSelect.selectedIndex].value
                    }
                    // fetch -- post to the create player route
                    fetch("/PlayersInput/Create/", {
                        method: "POST",
                        headers: {
                            'Content-type': 'application/json'
                        },
                        body: JSON.stringify(data)
                    }).then(function(res){return res.json()})
                })
            })
        });
});


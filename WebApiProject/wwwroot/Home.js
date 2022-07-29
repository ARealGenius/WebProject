
function hello() {
    fetch("api/Project")
        .then(res => {
            if (res.ok) {
                return res.text();
            }
            else { throw new Error("error" + res.status) }
        })
        .then(res => {
            document.getElementById("h2").innerHTML = res;

        })
        .catch((Error) => {
            console.log(Error)
        })
}

function login() {
    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    fetch("api/Project/" + email + "/" + password)
        .then((response) => {
            if (response.ok) {
                if (response.status == 204)
                    throw new Error("this user is not exist")
                else
                    return response.json()
            }
            else throw new Error(" server error" + response.status)
        }).then(data => {
            window.location.href = "login.html";
            sessionStorage.setItem('userDetails', JSON.stringify(data))
        })
        .catch(error => {
            alert(error);
        })

}

function newUser() {
    window.location.href = "NewUser.html";
}

function save() {
    let User = {
        name: document.getElementById("name").value,
        password: document.getElementById("password").value,
        email: document.getElementById("email").value,
    };

    fetch("api/project", {
        method: 'post',
        body: JSON.stringify(User),
        headers: { 'Content-Type': 'application/json' }
    }).then(result => result.json())
        .then((data => {
            if (data) {
                alert("user was added")
            }
            else {
                alert("error in add user")
            }
        })).then(() => { window.location.href = "Home.html"; }).catch(error => {
            alert(error)
        });
}

function update() {
    let userDetails = JSON.parse(sessionStorage.getItem('userDetails'));
    let User = {
        UserId: userDetails.userId,
        name: document.getElementById("Name").value,
        password: document.getElementById("Password").value,
        email: document.getElementById("Email").value,
    };

    fetch("api/project/" + User.UserId, {
        method: 'PUT',
        body: JSON.stringify(User),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then((data) => {
        if (data.ok)
            alert("user was update successfully")
        else
            alert("ctor update user")
    }).catch(error => {
        alert(error)
    })
}

function myName() {
    document.getElementById("oldName").innerHTML = JSON.parse(sessionStorage.getItem('userDetails')).name;
}

function updateShow() {
    document.getElementById("uptateDetails").style.display = "block";
    document.getElementById("Password").value = JSON.parse(sessionStorage.getItem('userDetails')).password;
    document.getElementById("Name").value = JSON.parse(sessionStorage.getItem('userDetails')).name;
    document.getElementById("Email").value = JSON.parse(sessionStorage.getItem('userDetails')).email
}

function back() {
    window.location.href = "Home.html";
}
import Vue from 'vue'

export default {
  resetPasswordVerifyToken: (id, code, password, passwordConfirm) => {
    const data = {
      userId: id,
      code: code,
      password: password,
      passwordConfirm: passwordConfirm
    }
    return Vue.$http.post('api/account/PasswordReset', data).then((x) => {
      return x
    }).catch(error => {
      return error
    })
  },
  forgotPassword: (email) => {
    const data = {
      email: email
    }
    return Vue.$http.post('api/account/ForgotPassword', data).then((x) => {
      return x
    }).catch(error => {
      return error
    })
  },
  signIn: (email, password) => {
    const data = {
      email: email,
      password: password
    }
    // console.log(data)
    return Vue.$http.post('api/auth/login', data).then((x) => {
      return x
    }).catch(error => {
      // console.log('api')
      // console.log(error.response.data)
      // console.log(error.response.status)
      return error
    })
  },
  signUp: (email, password, passwordConfirm, firstName, lastName) => {
    const data = {
      email: email,
      password: password,
      passwordConfirm: passwordConfirm,
      firstName: firstName,
      lastName: lastName
    }
    // console.log(data)
    return Vue.$http.post('api/account/register', data).then((x) => {
      return x
    }).catch(error => {
      // console.log('api')
      // console.log(error.response.data)
      // console.log(error.response.status)
      return error
    })
  }
}

// const users = [
//   {id: 1, email: 'email1@mail.ru', login: 'login1', password: 'pass'},
//   {id: 2, email: 'email2@mail.ru', login: 'login2', password: 'pass'},
//   {id: 3, email: 'email3@mail.ru', login: 'login3', password: 'pass'},
//   {id: 4, email: 'email4@mail.ru', login: 'login4', password: 'pass'}
// ]

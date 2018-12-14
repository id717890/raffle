export default function (Vue) {
  Vue.auth = {
    getToken () {
      if (this.isExpired()) {
        this.logout()
        return null
      }
      let token = localStorage.getItem('token')
      if (!token) {
        return null
      }
      return token
    },
    getUser () {
      if (this.isExpired()) {
        this.logout()
        return null
      }
      let user = localStorage.getItem('id')
      if (!user) {
        return null
      }
      return user
    },
    getCredentials () {
      if (this.isExpired()) {
        this.logout()
        return null
      }
      let token = localStorage.getItem('token')
      let id = localStorage.getItem('id')
      if (!token) {
        return null
      }
      return {token, id}
    },
    isExpired () {
      let expiration = localStorage.getItem('expiration')
      if (!expiration) {
        return true
      }
      if (Date.now() > parseInt(expiration)) {
        return true
      }
      return false
    },
    setToken (token, expiration) {
      localStorage.setItem('token', token)
      localStorage.setItem('expiration', expiration)
    },
    setUser (user) {
      localStorage.setItem('id', user)
    },
    logout () {
      localStorage.removeItem('token')
      localStorage.removeItem('expiration')
      localStorage.removeItem('id')
    }
    // isAuth () {
    //   if (this.getToken()) return true
    //   return false
    // },
    // hasRole (role) {
    //   if (this.isAuth() === true && this.decodeToken().role) {
    //     const roleFind = this.decodeToken().role.find(x => x === role)
    //     if (!roleFind || roleFind === null) return false
    //     else return true
    //   }
    //   return false
    // },
    // getUser () {
    //   if (this.isAuth() === true && this.decodeToken().uid) {
    //     return this.decodeToken().uid
    //   }
    //   return null
    // },
    // decodeToken () {
    //   var base64Url = this.getToken().split('.')[1]
    //   var base64 = base64Url.replace('-', '+').replace('_', '/')
    //   return JSON.parse(window.atob(base64))
    // }
  }
  Object.defineProperties(Vue.prototype, {
    $auth: {
      get () {
        return Vue.auth
      }
    }
  })
}

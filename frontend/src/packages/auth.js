export default function (Vue) {
  // let authUser = {};

  Vue.auth = {
    getToken () {
      const token = localStorage.getItem('token')
      if (!token) {
        return null
      }
      return token
    },
    setToken (token) {
      localStorage.setItem('token', token)
    },
    destroyToken () {
      localStorage.removeItem('token')
    },
    isAuth () {
      if (this.getToken()) return true
      return false
    },
    hasRole (role) {
      if (this.isAuth() === true && this.decodeToken().role) {
        const roleFind = this.decodeToken().role.find(x => x === role)
        if (!roleFind || roleFind === null) return false
        else return true
      }
      return false
    },
    getUser () {
      if (this.isAuth() === true && this.decodeToken().uid) {
        return this.decodeToken().uid
      }
      return null
    },
    decodeToken () {
      var base64Url = this.getToken().split('.')[1]
      var base64 = base64Url.replace('-', '+').replace('_', '/')
      return JSON.parse(window.atob(base64))
    }
  }
  Object.defineProperties(Vue.prototype, {
    $auth: {
      get () {
        return Vue.auth
      }
    }
  })
}

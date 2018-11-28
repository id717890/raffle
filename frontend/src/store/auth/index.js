import * as types from '../mutation-types'
import context from '@/api/auth'
// import Vue from 'vue'

const state = {
  user: null,
  isAuth: false
}

// getters
const getters = {
  getUser (state) {
    return state.user
  },
  getError (state) {
    return state.error
  },
  getLoading (state) {
    return state.loading
  },
  isAuth: state => state.user != null
}

// actions
const actions = {
  // resetPassword ({commit}, payload) {
  //   commit(types.SET_LOADING, true)
  //   commit(types.CLEAR_ERROR)
  //   return firebase.auth().sendPasswordResetEmail(payload)
  //     .then(() => {
  //       commit(types.SET_LOADING, false)
  //       // x.user.sendEmailVerification()
  //       // commit(types.SET_LOADING, false)
  //       // const newUser = {
  //       //   id: x.user.uid
  //       // }
  //       // commit(types.SET_USER, newUser)
  //     })
  //     .catch(e => {
  //       commit(types.SET_LOADING, false)
  //       commit(types.SET_ERROR, e)
  //       console.log(e)
  //     })
  // },
  // signUserUp ({commit}, payload) {
  //   commit(types.SET_LOADING, true)
  //   commit(types.CLEAR_ERROR)
  //   firebase.auth().createUserWithEmailAndPassword(payload.email, payload.password)
  //     .then(x => {
  //       x.user.sendEmailVerification()
  //       commit(types.SET_LOADING, false)
  //       const newUser = {
  //         id: x.user.uid
  //       }
  //       commit(types.SET_USER, newUser)
  //     })
  //     .catch(e => {
  //       commit(types.SET_LOADING, false)
  //       commit(types.SET_ERROR, e)
  //       console.log(e)
  //     })
  // },
  forgotPassword ({dispatch}, payload) {
    return new Promise((resolve, reject) => {
      context.forgotPassword(payload.email).then((x) => {
        if (x.status === 200) {
          dispatch('setMessages', ['На указанный E-mail выслана инструкция для восстановления пароля'])
          resolve()
        } else {
          dispatch('setErrors', x.response.data)
          reject(x.response.data)
        }
      }).catch(x => {
        reject(x.response.data)
      })
    })
  },
  signUserIn ({dispatch}, payload) {
    return new Promise((resolve, reject) => {
      context.signIn(payload.email, payload.password).then((x) => {
        if (x.status === 200) {
          console.log(x)
          resolve()
        } else {
          dispatch('setErrors', x.response.data)
          reject(x.response.data)
        }
      }).catch(x => {
        reject(x.response.data)
      })
    })
  },
  signUserUp ({dispatch}, payload) {
    return new Promise((resolve, reject) => {
      context.signUp(payload.email, payload.password, payload.passwordConfirm, payload.firstName, payload.lastName).then((x) => {
        if (x.status === 200) {
          dispatch('setMessages', ['Accont create. Please, confirm your email address.'])
          resolve()
        } else {
          dispatch('setErrors', x.response.data)
          reject(x.response.data)
        }
      }).catch(x => {
        reject(x.response.data)
      })
    })
  },
  logout ({commit}) {
    commit(types.SET_USER, null)
  }
  // autoSignIn ({commit}, payload) {
  //   commit(types.SET_USER, {id: payload.uid})
  // },
  // logout ({commit}) {
  //   if (!config.isLocalApp()) {
  //     firebase.auth().signOut()
  //   }
  //   commit(types.SET_USER, null)
  // },
  // clearError ({commit}) {
  //   commit(types.CLEAR_ERROR)
  // }
}

// mutations
const mutations = {
  [types.SET_USER] (state, payload) {
    state.user = payload
  },
  [types.SET_LOADING] (state, payload) {
    state.loading = payload
  },
  // [types.SET_ERROR] (state, payload) {
  //   state.error = payload
  // },
  [types.SIGN_UP] (state, payload) {
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}

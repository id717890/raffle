/* eslint-disable */
import * as types from '../mutation-types'

const state = {
  errors: null,
  messages: null
}

const actions = {
  setErrors ({commit}, payload) {
    commit(types.SET_ERRORS, payload)
  },
  setMessages ({commit}, payload) {
    commit(types.SET_MESSAGES, payload)
  },
  clearAllMessages ({commit}) {
    commit(types.SET_ERRORS, null)
    commit(types.SET_MESSAGES, null)
  },
} 

const getters = {
  getErrors: state => state.errors,
  getMessages: state => state.messages
}

const mutations = {
  [types.CLEAR_ERRORS] (state) {
    state.errors = null
  },
  [types.SET_ERRORS] (state, payload) {
    state.errors = payload
  },
  [types.SET_MESSAGES] (state, payload) {
    state.messages = payload
  }
}

export default {
  state,
  getters,
  actions,
  mutations,
}

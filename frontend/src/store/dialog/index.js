import * as types from '../mutation-types'

const state = {
  isConfirmed: false
}

// getters
const getters = {
  getResultConfirmDialog: state => state.isConfirmed
}

// actions
const actions = {
  setConfirmDialogResult ({commit}, data) {
    commit(types.SET_CONFIRM_DIALOG_RESULT, data)
  },
  resetConfirmDialogResult ({commit}) {
    commit(types.RESET_CONFIRM_DIALOG_RESULT, false)
  }
}

// mutations
const mutations = {
  [types.SET_CONFIRM_DIALOG_RESULT] (state, payload) {
    state.isConfirmed = payload
  },
  [types.RESET_CONFIRM_DIALOG_RESULT] (state) {
    state.isConfirmed = false
  }
}

export default {
  state,
  getters,
  actions,
  mutations,
  namespaced: true
}

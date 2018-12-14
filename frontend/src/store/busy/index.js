import * as types from '../mutation-types'

const state = {
  loading: false
}

// getters
const getters = {
  loading: state => state.loading
}

// actions
const actions = {
  setLoading ({commit}, payload) {
    commit(types.SET_LOADING, payload)
  }
  // setLoading: {
  //   root: true,
  //   handler ({commit}, payload) {
  //     console.log('loading')
  //     commit(types.SET_LOADING, payload)
  //   }
  // }
}

// mutations
const mutations = {
  [types.SET_LOADING] (state, payload) {
    state.loading = payload
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}

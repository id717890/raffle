import * as types from '../mutation-types'
import context from '@/api/vote'
import config from '@/packages/config'

const state = {
  votes: []
}

// actions
const actions = {
  reciveVotes ({commit, dispatch}) {
    return new Promise((resolve, reject) => {
      context.getVotes().then((x) => {
        if (config.isLocalApp()) {
          commit(types.RECIEVE_VOTES, x)
          commit(types.SET_LOADING, false)
          resolve()
        } else {
          if (x.status === 200) {
            commit(types.RECIEVE_VOTES, x.data)
            resolve()
          } else {
            dispatch('setErrors', x.response.data)
            reject(x.response.data)
          }
        }
      }).catch(x => {
        reject(x.response.data)
      })
    })
  }
}

// mutations
const mutations = {
  [types.RECIEVE_VOTES] (state, payload) {
    state.votes = payload
  }
}

// getters
const getters = {
}

export default {
  state,
  getters,
  actions,
  mutations
}

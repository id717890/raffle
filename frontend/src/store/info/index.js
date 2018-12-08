import * as types from '../mutation-types'
import context from '@/api/info'
import config from '@/packages/config'

const state = {
  info: null
}

// actions
const actions = {
  async reciveInfo ({commit, dispatch}) {
    return new Promise((resolve, reject) => {
      context.getInfo().then((x) => {
        if (config.isLocalApp()) {
          commit(types.RECIEVE_INFO, x)
          commit(types.SET_LOADING, false)
          resolve()
        } else {
        }
      }).catch(x => {
        reject(x.response.data)
      })
    })
  }
}

// mutations
const mutations = {
  [types.RECIEVE_INFO] (state, payload) {
    state.info = payload
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

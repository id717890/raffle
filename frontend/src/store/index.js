import Vue from 'vue'
import Vuex from 'vuex'
import * as types from './mutation-types'
import auth from './auth'
import notify from './notify'
// import word from './word'
// import busy from './busy'
// import dialog from './dialog'
// import training from './training'

Vue.use(Vuex)

export const store = new Vuex.Store({
  plugins: [
    store => {
      store.subscribeAction((action, state) => {
        store.commit(types.CLEAR_ERRORS)
      })
    }
  ],
  modules: {
    auth,
    notify
    // category,
    // word,
    // busy
    // dialog,
    // training
  }
})

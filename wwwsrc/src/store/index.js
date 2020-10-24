import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    keeps: [],
    vaults: []
  },
  mutations: {

    //#region Profile
    setProfile(state, profile) {
      state.profile = profile;
    },
    //#endregion

    //#region Keeps


    //#endregion

    //#region Vaults


    //#endregion

  },
  actions: {


    //#region Profile

    async getProfile({ commit }) {
      try {
        let res = await api.get("profiles");
        commit("setProfile", res.data);
      } catch (error) {
        console.error(error);
      }
    },

    //#endregion

    //#region Keeps


    //#endregion

    //#region Vaults


    //#endregion


  },
});

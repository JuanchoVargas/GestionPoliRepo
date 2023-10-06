import api from "@/utils/api";
import { defineStore } from "pinia";
export const useNucleoStore = defineStore({
  id: "nucleo",
  state: () => ({
    items: [],
  }),
  actions: {
    limpiar() {
      this.items = [];
    },
    async all() {
      console.log("Nucleo items =>", this.items);
      if (this.items.length > 0) return this.items;
      return await api()
        .get(`cursoNucleo/all`)
        .then(async (r) => {
          this.items = r.data;
          return this.items;
        });
    },
    async getById(id) {
      if (this.items.length <= 0) await this.all();
      return this.items.find((o) => o.id == id);
    },

    async nucleosPorBancoProgramaId(bancoId) {
      let items = await this.all();
      //   console.log("Nucleos =>", items);
      return items.filter((o) => o.bancoId == bancoId);
    },
  },
});

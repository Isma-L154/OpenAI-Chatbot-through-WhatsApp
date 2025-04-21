## 🧑‍💻 
Ismael Leon Saenz

# 💬 Tech Assistant Chatbot API (.NET + OpenAI + Twilio Sandbox)

This project is a .NET-based REST API designed to integrate **OpenAI's API** with the **Twilio WhatsApp Sandbox** to power a specialized chatbot for **technology and software development support**.

---

## 🚀 Overview

This API receives messages via Twilio (WhatsApp), processes them with OpenAI's API (using GPT models), and returns intelligent responses. The assistant is designed to **only answer queries related to IT and software development**.

---

## 🧩 Technologies Used

- **.NET 6 (Web API)** – Backend framework
- **OpenAI API** – Natural language processing (GPT models)
- **Twilio Sandbox for WhatsApp** – Message delivery and reception
- **Azure** – Used to securely expose the API endpoint for Twilio to access
- **C#** – Programming language

---

## 🧠 Features

- 📱 WhatsApp chatbot interface using Twilio Sandbox
- 🤖 OpenAI GPT integration for natural, context-aware responses
- 🧑‍💻 Pre-configured to only respond to tech-related questions
- ☁️ Azure-compatible: Easily host the API for public access
- 🔐 No API Keys or credentials are stored in this repo — safe to explore and fork!

---

## 🛠️ How It Works

1. Twilio (Sandbox) receives a message sent to the test WhatsApp number.
2. The message is sent to this .NET API via an HTTP webhook.
3. The API uses OpenAI to generate a response based on the message.
4. The reply is returned to the WhatsApp user via Twilio.

> ✨ Azure is used to host this API, so Twilio can reach the public endpoint.

---

## 🔗 Related Repositories and Tools

- 🧱 Check out this awesome [**.NET API Template**](https://github.com/JoseAlvarado13/GuideStructureAPI) created by a friend that helped me in this project. A solid starting point for any C# Web API project — well structured and vrey easy to scale.
- 🔗 Uses [**Twilio Sandbox for WhatsApp**](https://www.twilio.com/whatsapp) to handle incoming and outgoing messages via WhatsApp.

---

## ⚠️ Important Notes

- ✅ This project is **sandbox-ready** — works directly with Twilio’s WhatsApp testing environment.
- 🚫 There are **no hardcoded API Keys or Twilio credentials** included.
- 🔐 It is recommended to use **environment variables** to safely manage your OpenAI API key.

---

## 📦 How to Use

1. Clone the repository.
2. Set up your API Key.
3. Run the API using Visual Studio or `dotnet run`.
4. Connect your Twilio Sandbox webhook to the hosted Azure endpoint (Not necesary to be on Azure).
5. Send a message via WhatsApp and receive a smart, tech-focused reply.

---


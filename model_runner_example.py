import json
import matplotlib.pyplot as plt
import numpy as np
import os

# 결과 디렉토리
RESULT_DIR = "./ModelResults"
os.makedirs(RESULT_DIR, exist_ok=True)

# ------------------------------
# 1. 연관 인자 (동적으로 가정)
# ------------------------------
related_variables = {
    "Temperature": round(np.random.rand(), 2),
    "Pressure": round(np.random.rand(), 2),
    "FlowRate": round(np.random.rand(), 2)
}

# ------------------------------
# 2. 모델 성능 지표
# ------------------------------
model_metrics = {
    "accuracy": round(np.random.uniform(0.9, 0.98), 3),
    "rmse": round(np.random.uniform(0.5, 2.0), 2),
    "r2": round(np.random.uniform(0.8, 0.95), 2)
}

# ------------------------------
# 3. JSON 저장
# ------------------------------
result_data = {
    "related_variables": related_variables,
    "metrics": model_metrics
}
with open(os.path.join(RESULT_DIR, "result.json"), "w") as f:
    json.dump(result_data, f, indent=4)

# ------------------------------
# 4. 유클리드 이미지 생성
# ------------------------------
x = np.random.rand(10)
y = np.random.rand(10)
plt.figure(figsize=(5, 5))
plt.scatter(x, y, c='blue', edgecolors='black')
plt.title("Euclidean Space Example")
plt.xlabel("X")
plt.ylabel("Y")
plt.grid(True)
plt.savefig(os.path.join(RESULT_DIR, "euclid.png"))
plt.close()

# ------------------------------
# 5. 모델 성능 그래프 생성
# ------------------------------
labels = list(model_metrics.keys())
values = list(model_metrics.values())

plt.figure(figsize=(6, 4))
bars = plt.bar(labels, values, color=['green', 'orange', 'blue'])
plt.ylim(0, 1.5)
plt.title("Model Performance")
plt.ylabel("Score")

# 숫자 라벨 추가
for bar in bars:
    yval = bar.get_height()
    plt.text(bar.get_x() + bar.get_width()/2, yval + 0.02, f"{yval:.2f}", ha='center')

plt.tight_layout()
plt.savefig(os.path.join(RESULT_DIR, "performance.png"))
plt.close()

print("Model results saved to ./ModelResults/")

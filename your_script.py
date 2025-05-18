import matplotlib.pyplot as plt
import sys
import pandas as pd 
import numpy as np
import os
from datetime import datetime

def generate_plot(input_file_path):

    #input_file_path = r"C:\Users\cmg11\Desktop\4-1\산프2\gui_연숩\WpfApp2\preprocessed_data\run_gasflow_avg_dataset.csv"
    df = pd.read_csv(input_file_path, encoding = 'utf-8')

    #특정 파장을 선택한다. 극댓값들은 일치하는 부분이 유사하다.

    localMaximaOverThreshold = set()
    for i in range(37):
        row_index = i  #인덱스 번호

        # 1단계: 특정 행의 극대값 찾기
        row_values = df.iloc[row_index]
        row_values = row_values[row_values >= 4000]  # 특정 행 값
        is_local_maxima = (row_values > row_values.shift(1)) & (row_values > row_values.shift(-1))

        # 2단계: 극대값에 해당하는 열 반환
        local_maxima_columns = row_values[is_local_maxima].index.tolist()
        print(f"index {i}:", end = '')
        print(local_maxima_columns)
        print(len(local_maxima_columns))
        localMaximaOverThreshold.update(local_maxima_columns)

    localMaximaOverThreshold = sorted(list(localMaximaOverThreshold) ,key = lambda x: float(x))
    print("final_result", localMaximaOverThreshold)
    print(len(localMaximaOverThreshold))

    recipe = [ 200, 200, 200, 200, 200,  #정상 run1 - run5
               202, 204, 206, 208, 210, 212, 214, #증가 run6 - run12
               200, 200, 200, 200, 200, #정상 run13 - run17
               198, 196, 194, 192, 190, 188, 186, #감소 run18 - run24
               200, 200, 200, 200, 200, #정상 run25 - run29
               202, 204, 206, 208, 210, 212, 214, #증가 run30 - run36
               200, 200, 200, 200, 200, #정상 run37 - run41
               198, 196, 194, 192, 190, 188, 186, #감소 run42 - run48
               200, 200, 200, 200, 200, #정상 run49 - run53
    ]

    sih4_drift = list(map(lambda x: x / 200, recipe))

    df['drift_index'] = (df['357.668'] / df['380.436'])**2.4 * (df['414.028'] / df['660.868'])


    import numpy as np
    from scipy.stats import linregress

    start = 1
    end = 36

    line_result = []
    # 두 배열
    X = sih4_drift[start - 1:end]

    for feature in localMaximaOverThreshold:
        Y = df.loc[start - 1:end - 1, feature]

        correlation = np.corrcoef(X, Y)[0, 1]

        slope, intercept, r_value, p_value, std_err = linregress(X, Y)
        line_result.append([feature, r_value])

    line_result.sort(key = lambda x: x[1], reverse = True)

    for i in range(len(line_result)):
        print(line_result[i])

    import numpy as np
    from scipy.stats import linregress

    start = 1
    end = 36

    ratio_result = []
    # 두 배열
    X = sih4_drift[start - 1:end]
    N = len(localMaximaOverThreshold)
    for i in range(N):
        for j in range(i + 1, N):
            Y = df.loc[start - 1:end - 1, localMaximaOverThreshold[i]] / df.loc[start - 1:end - 1, localMaximaOverThreshold[j]]

            correlation = np.corrcoef(X, Y)[0, 1]

            slope, intercept, r_value, p_value, std_err = linregress(X, Y)
            ratio_result.append([f"{localMaximaOverThreshold[i]} / {localMaximaOverThreshold[j]}", r_value])

    ratio_result.sort(key = lambda x: x[1], reverse = True)

    for i in range(len(ratio_result)):
        print(ratio_result[i])


    start = 1
    end = 36

    def show_relationship(column, start, end):
        plt.scatter(recipe[start:end + 1], df.loc[start:end, column])

        # 축 라벨 설정
        plt.xlabel('SiH4 drift')
        plt.ylabel(column)

        # 그래프 제목 설정
        plt.title(f'relationship between SiH4 and {column}')

        #now = datetime.now().strftime("%Y%m%d_%H%M%S")
        #filename = f"sine_wave_{now}.png"
        script_dir = os.path.dirname(os.path.abspath(__file__))
        image_dir = os.path.join(script_dir, "image")
        save_path = os.path.join(image_dir, "sine_wave.png")
        plt.savefig(save_path)
        #plt.savefig(r"..\image\sine_wave.png")
        #plt.savefig(filename)
            
    show_relationship('drift_index', start, end)


if __name__ == "__main__":
    input_file = r"C:\Users\민기조\Desktop\4-1강의자료들\산프\preprocessed_data\run_gasflow_avg_dataset.csv" #sys.argv[1]  # WPF에서 전달된 파일 경로 받기
    generate_plot(input_file)
    print("Plot generated successfully")
